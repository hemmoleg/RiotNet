﻿using RestSharp;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetMatchRequest(long matchId, Boolean includeTimeline)
        {
            var request = Get("api/lol/{region}/v2.2/match/{matchId}");
            request.AddUrlSegment("matchId", matchId.ToString());
            request.AddQueryParameter("includeTimeline", includeTimeline.ToString().ToLower());
            return request;
        }

        /// <summary>
        /// Gets the details of a match (a.k.a. game ID).
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>The details of the match.</returns>
        public MatchDetail GetMatch(long matchId, Boolean includeTimeline)
        {
            return Execute<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }

        /// <summary>
        /// Gets the details of a match (a.k.a. game ID).
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchTaskAsync(long matchId, Boolean includeTimeline)
        {
            return ExecuteTaskAsync<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }
    }
}
