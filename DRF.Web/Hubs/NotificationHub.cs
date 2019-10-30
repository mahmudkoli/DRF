using DRF.Services;
using Microsoft.AspNet.SignalR;
using DRF.Web.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DRF.Web.Models.NotificationModels;
using DRF.Entities;

namespace DRF.Web.Hubs
{
    //[Authorize]
    public class NotificationHub : Hub
    {
        private static readonly ConcurrentDictionary<int, UserHubModel> Users =
            new ConcurrentDictionary<int, UserHubModel>();
        private int _loggedUserId;

        private NotificationService _notificationService;

        public NotificationHub()
        {
            _notificationService = new NotificationService(); 
            _loggedUserId = AuthenticatedUserModel.GetUserFromIdentity().Id;
        }

        //Logged Use Call
        public void GetNotification()
        {
            try
            {
                //Get TotalNotification
                var notifyData = _notificationService.GetAllNotifyByNotifierId(_loggedUserId);

                //Send To
                UserHubModel receiver;
                if (Users.TryGetValue(_loggedUserId, out receiver))
                {
                    var cid = receiver.ConnectionIds.FirstOrDefault();
                    var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                    context.Clients.Client(cid).broadcastNotify(notifyData);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //Specific User Call
        public void SendNotification(int userId)
        {
            try
            {
                //Get TotalNotification
                var notifyData = _notificationService.GetAllNotifyByNotifierId(userId);

                //Send To
                UserHubModel notifier;
                if (Users.TryGetValue(userId, out notifier))
                {
                    var cid = notifier.ConnectionIds.FirstOrDefault();
                    var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                    context.Clients.Client(cid).broadcastNotify(notifyData);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public override Task OnConnected()
        {
            string connectionId = Context.ConnectionId;

            var notifier = Users.GetOrAdd(_loggedUserId, _ => new UserHubModel
            {
                UserId = _loggedUserId,
                ConnectionIds = new HashSet<string>()
            });

            lock (notifier.ConnectionIds)
            {
                notifier.ConnectionIds.Add(connectionId);
                if (notifier.ConnectionIds.Count == 1)
                {
                    Clients.Others.userConnected(_loggedUserId);
                }
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string connectionId = Context.ConnectionId;

            UserHubModel notifier;
            Users.TryGetValue(_loggedUserId, out notifier);

            if (notifier != null)
            {
                lock (notifier.ConnectionIds)
                {
                    notifier.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!notifier.ConnectionIds.Any())
                    {
                        UserHubModel removedNotifier;
                        Users.TryRemove(_loggedUserId, out removedNotifier);
                        Clients.Others.userDisconnected(_loggedUserId);
                    }
                }
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}