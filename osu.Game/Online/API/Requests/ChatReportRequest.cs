// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Net.Http;
using osu.Framework.IO.Network;
using osu.Game.Overlays.Comments;

namespace osu.Game.Online.API.Requests
{
    public class ChatReportRequest : APIRequest
    {
        public readonly long UserID;
        public readonly CommentReportReason Reason;
        public readonly string Message;

        public ChatReportRequest(long userID, CommentReportReason reason, string message)
        {
            UserID = userID;
            Reason = reason;
            Message = message;
        }

        protected override WebRequest CreateWebRequest()
        {
            var req = base.CreateWebRequest();
            req.Method = HttpMethod.Post;

            req.AddParameter(@"reportable_type", @"message");
            req.AddParameter(@"reportable_id", $"{UserID}");
            req.AddParameter(@"reason", Reason.ToString());
            req.AddParameter(@"messages", Message);

            return req;
        }

        protected override string Target => @"reports";
    }
}
