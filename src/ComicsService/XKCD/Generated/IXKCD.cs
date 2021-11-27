// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ComicApiGrpc.ComicsService.XKCD.Generated;

using Microsoft.Rest;
using Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Webcomic of romance, sarcasm, math, and language.
/// </summary>
public partial interface IXKCD : System.IDisposable
{
    /// <summary>
    /// The base URI of the service.
    /// </summary>
    System.Uri BaseUri { get; set; }

    /// <summary>
    /// Gets or sets json serialization settings.
    /// </summary>
    JsonSerializerSettings SerializationSettings { get; }

    /// <summary>
    /// Gets or sets json deserialization settings.
    /// </summary>
    JsonSerializerSettings DeserializationSettings { get; }


    /// <summary>
    /// Fetch current comic and metadata.
    ///
    /// </summary>
    /// <param name='customHeaders'>
    /// The headers that will be added to request.
    /// </param>
    /// <param name='cancellationToken'>
    /// The cancellation token.
    /// </param>
    Task<HttpOperationResponse<Comic>> GetLatestComicWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Fetch comics and metadata  by comic id.
    ///
    /// </summary>
    /// <param name='comicId'>
    /// </param>
    /// <param name='customHeaders'>
    /// The headers that will be added to request.
    /// </param>
    /// <param name='cancellationToken'>
    /// The cancellation token.
    /// </param>
    Task<HttpOperationResponse<Comic>> GetComicByIdWithHttpMessagesAsync(int comicId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

}
