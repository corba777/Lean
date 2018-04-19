﻿using Newtonsoft.Json;

namespace QuantConnect.Algorithm.Framework.Alphas.Serialization
{
    /// <summary>
    /// DTO used for serializing an insight that was just generated by an algorithm.
    /// This type does not contain any of the analysis dependent fields, such as scores
    /// and estimated value
    /// </summary>
    public class SerializedInsight
    {
        /// <summary>
        /// See <see cref="Insight.Id"/>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// See <see cref="Insight.SourceModel"/>
        /// </summary>
        [JsonProperty("source-model")]
        public string SourceModel { get; set; }

        /// <summary>
        /// See <see cref="Insight.GeneratedTimeUtc"/>
        /// </summary>
        [JsonProperty("generated-time")]
        public double GeneratedTime { get; set; }

        /// <summary>
        /// See <see cref="Insight.CloseTimeUtc"/>
        /// </summary>
        [JsonProperty("close-time")]
        public double CloseTime { get; set; }

        /// <summary>
        /// See <see cref="Insight.Symbol"/>
        /// The symbol's security identifier string
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// See <see cref="Insight.Symbol"/>
        /// The symbol's ticker at the generated time
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// See <see cref="Insight.Type"/>
        /// </summary>
        [JsonProperty("type")]
        public InsightType Type { get; set; }

        /// <summary>
        /// See <see cref="Insight.ReferenceValue"/>
        /// </summary>
        [JsonProperty("reference")]
        public decimal ReferenceValue { get; set; }

        /// <summary>
        /// See <see cref="Insight.Direction"/>
        /// </summary>
        [JsonProperty("direction")]
        public InsightDirection Direction { get; set; }

        /// <summary>
        /// See <see cref="Insight.Period"/>
        /// </summary>
        [JsonProperty("period")]
        public double Period { get; set; }

        /// <summary>
        /// See <see cref="Insight.Magnitude"/>
        /// </summary>
        [JsonProperty("magnitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Magnitude { get; set; }

        /// <summary>
        /// See <see cref="Insight.Confidence"/>
        /// </summary>
        [JsonProperty("confidence", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Confidence { get; set; }

        /// <summary>
        /// See <see cref="InsightScore.IsFinalScore"/>
        /// </summary>
        [JsonProperty("score-final", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ScoreIsFinal { get; set; }

        /// <summary>
        /// See <see cref="InsightScore.Magnitude"/>
        /// </summary>
        [JsonProperty("score-magnitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ScoreMagnitude { get; set; }

        /// <summary>
        /// See <see cref="InsightScore.Direction"/>
        /// </summary>
        [JsonProperty("score-direction", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ScoreDirection { get; set; }

        /// <summary>
        /// See <see cref="Insight.EstimatedValue"/>
        /// </summary>
        [JsonProperty("estimated-value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal EstimatedValue { get; set; }

        /// <summary>
        /// Initializes a new default instance of the <see cref="SerializedInsight"/> class
        /// </summary>
        public SerializedInsight()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializedInsight "/> class by copying the specified insight
        /// </summary>
        /// <param name="insight">The insight to copy</param>
        public SerializedInsight(Insight insight)
        {
            Id = insight.Id.ToString("N");
            SourceModel = insight.SourceModel;
            GeneratedTime = Time.DateTimeToUnixTimeStamp(insight.GeneratedTimeUtc);
            CloseTime = Time.DateTimeToUnixTimeStamp(insight.CloseTimeUtc);
            Symbol = insight.Symbol.ID.ToString();
            Ticker = insight.Symbol.Value;
            Type = insight.Type;
            ReferenceValue = insight.ReferenceValue;
            Direction = insight.Direction;
            Period = insight.Period.TotalSeconds;
            Magnitude = insight.Magnitude;
            Confidence = insight.Confidence;
            ScoreIsFinal = insight.Score.IsFinalScore;
            ScoreMagnitude = insight.Score.Magnitude;
            ScoreDirection = insight.Score.Direction;
            EstimatedValue = insight.EstimatedValue;
        }
    }
}