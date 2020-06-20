using Quartz;
using RestSharp;
using SelfHosting.Common;
using SelfHosting.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosting.Services.JobExecuter
{
    public class JobExecuter : IJob
    {

        /// <summary>
        /// Job'ı çalıştıran method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {

            JobDataMap dataMap = context.MergedJobDataMap;

            //Gidilecek Url bilgisini string olarak alıyoruz.
            var BaseUrl = dataMap.GetString("BaseUrl");


            //Endpoint bilgisini string olarak alıyoruz.
            var EndPoint = dataMap.GetString("EndPoint");


            ///Generic bir yapı oluşturabilmek için abstract factory method ile yakaladığımız sınıfı burda tetikliyoruz.
            ///Hangi Job Sınıfı bize döndürülürse onu çalıştıracağız.
            var SchedulerJob = (ISchedulerJob)dataMap.Get("SchedulerJob");
            
           await SchedulerJob.ExecuteJobAsync(BaseUrl, EndPoint);

        }
    }
}
