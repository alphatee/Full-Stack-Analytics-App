using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripInfo.API.Entities;

namespace TripInfo.API.Services.MailServices;

public interface IEmailService
{
    Task SendSumOfTipsByGroup(Func<Task<IEnumerable<MetaData>>> getMetaData, string subject, string groupBy);
}

/**
 * In this interface, SendSumOfTipsByGroup is an asynchronous method that takes a function to retrieve the metadata, a subject for the email, and a string to specify the group by field. The function to retrieve the metadata is expected to return a task that results in an IEnumerable<MetaData>. This allows you to pass in different methods to retrieve the metadata, such as _tripInfoService.GetSumOfTipsByStoreName, _tripInfoService.GetSumOfTipsByCity, etc.
*/
