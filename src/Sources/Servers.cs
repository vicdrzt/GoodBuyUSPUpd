using NetTopologySuite.Index.IntervalRTree;
using System.ComponentModel.Design;

namespace GoodbyeUsp.Sources
{
    internal class Servers
    {

        public static string[] ConnectionStrings = new[]
        {
            //if (!args.Any(a => new[] { "-dbcreate=no" }.Contains(a))){ 
            //}
            //"Data Source=gies3;Initial Catalog=energy_zt;Integrated Security=True",
            //"Data Source=10.67.5.10;Initial Catalog=energy;Integrated Security=True",
            "Data Source=anes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=bnes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=bdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=bres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=hres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
             //"Data Source=emes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=ztes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
             //"Data Source=zres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=kres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=ktes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=lbes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=mles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=zves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=oves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=oles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=ppes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=rdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=rmes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=ples.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=ches.dso.zt.energy;Initial Catalog=energy;Integrated Security=True",
            "Data Source=cdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True"
        };
        public static string renone = "";
        public static List<string> ListConnStr = new List<string>();
        public static int LoadListConnStr() {
            if (renone.Length == 2)
            {
                switch (renone)
                {
                    case "an":
                        ListConnStr.Add("Data Source=anes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "bn":
                        ListConnStr.Add("Data Source=bnes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "br":
                        ListConnStr.Add("Data Source=bres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "bd":
                        ListConnStr.Add("Data Source=bdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "hr":
                        ListConnStr.Add("Data Source=hres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "zt":
                        //ListConnStr.Add("Data Source=gies3;Initial Catalog=energy_zt;Integrated Security=True"); //Test!
                        ListConnStr.Add("Data Source=ztes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "kr":
                        ListConnStr.Add("Data Source=kres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "kt":
                        ListConnStr.Add("Data Source=ktes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "lb":
                        ListConnStr.Add("Data Source=lbes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "ml":
                        ListConnStr.Add("Data Source=mles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "zv":
                        ListConnStr.Add("Data Source=zves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "ov":
                        ListConnStr.Add("Data Source=oves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "ol":
                        ListConnStr.Add("Data Source=oles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "pp":
                        ListConnStr.Add("Data Source=ppes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "rd":
                        ListConnStr.Add("Data Source=rdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "rm":
                        ListConnStr.Add("Data Source=rmes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "pl":
                        ListConnStr.Add("Data Source=ples.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "ch":
                        ListConnStr.Add("Data Source=ches.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    case "cd":
                        ListConnStr.Add("Data Source=cdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                        break;
                    default:
                        Console.WriteLine("Error using argument: -ren=");
                        break;
                }
            }
            else 
            {
                    ListConnStr.Add("Data Source=anes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=bnes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=bres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=bdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=hres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=ztes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=kres.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=ktes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=lbes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=mles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=zves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=oves.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=oles.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=ppes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=rdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=rmes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=ples.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=ches.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
                    ListConnStr.Add("Data Source=cdes.dso.zt.energy;Initial Catalog=energy;Integrated Security=True");
            }
            return 1;
        }
        //-- 09.02.2024 Для CodeOwner учтено наличие двух ЦОК в одном РЭС, в Житомирском РЭС - Заречанский ЦОК, В Звягельском - Емильчинский ЦОК (alex)
        //   25.02.2024 Номер договора всі заглавні літери 
        public static string SelectRecordpointQueryText = @"SELECT r.code clientId, UPPER(TRIM(r.name)) abcode, TRIM(r.eic) CodeEic, TRIM(p.fullperson) fio, cnt.datecreate
                , TRIM(ct.NAME)+' '+TRIM(c.NAME) namerg, TRIM(st.NAME) typstr, TRIM(s.NAME) namestreet, TRIM(a.LOCATIONHOUSE) LOCATIONHOUSE, TRIM(a.LOCATIONAPP) LOCATIONAPP, TRIM(r.Phone) Phone  
                , r.DistributionSystemOperatorId+100 CodeExchange, r.RENCODE CodeEnergyReal, CASE SUBSTRING(r.name,1,2) WHEN '05' THEN 206 WHEN '07' THEN 208 ELSE r.RENCODE+200 END CodeOwner
                FROM RECORDPOINT r, ADDRESS a, STREET s, STREETTYPE st, CITY c, CITYTYPE ct
                , ActualContract ac, ContractsHistory ch, personsview p, 
                (SELECT MIN(CASE WHEN ch1.StartDate<='1.1.2019' THEN '1.1.2019' ELSE ch1.StartDate END) datecreate, ch1.RecordpointId FROM ContractsHistory ch1 GROUP BY ch1.RecordpointId) cnt
                WHERE ac.RecordpointId=r.CODE AND ch.Id=ac.ContractId AND p.id = ch.PersonId AND r.CODE=cnt.RecordpointId AND COALESCE(r.ISTECHNICAL,0)!=1 and
                ServiceProviderId in (1, 2) AND r.ADDRESSREFCODE=a.CODE and a.STREETCODE =s.code AND s.STREETTYPECODE=st.CODE AND c.CODE = s.CITYCODE AND c.CITYTYPECODE = ct.CODE";

        public static string SelectTariffsQuery = @"SELECT t.RECORDPONTRFCODE RecordpointId, trim(t1.NAME) TariffName, t1.SETTLETYPECODE SettleTypeId, CAST('1.1.19' AS DATETIME2) StartDate,
                 t1.ConsumptionTypeId  FROM TARIFFHISTORY t, TARIFF t1, RECORDPOINT r, 
                 (SELECT t.RECORDPONTRFCODE, MAX(t.DATEGEN) StartDate FROM TARIFFHISTORY t WHERE t.DATEGEN<='1.1.19' GROUP BY t.RECORDPONTRFCODE) old_tariff
                 WHERE t1.CODE=t.TARIFFREFCODE AND r.CODE = t.RECORDPONTRFCODE AND COALESCE(r.ISTECHNICAL,0)!=1 AND ServiceProviderId=1 AND t.DATEGEN = old_tariff.StartDate 
                 AND old_tariff.RECORDPONTRFCODE =t.RECORDPONTRFCODE UNION all
                 SELECT t.RECORDPONTRFCODE RecordpointId, t1.NAME TariffName, t1.SETTLETYPECODE SettleTypeId, t.DATEGEN ,
                 t1.ConsumptionTypeId  FROM TARIFFHISTORY t, TARIFF t1, RECORDPOINT r WHERE t1.CODE=t.TARIFFREFCODE 
                 AND r.CODE = t.RECORDPONTRFCODE AND COALESCE(r.ISTECHNICAL,0)!=1 AND ServiceProviderId=1 AND t.DATEGEN>'1.1.19' ";

        public static string SelectConsumptionsQuery = @"SELECT * FROM (
                SELECT b.RECORDPONTRFCODE ClientId, bd.PeriodStartDate [month]
                , DAY(bd.PeriodStartDate) BeginDay,  DAY(DATEADD(DAY,-1, DATEADD(MONTH, 1, bd.PeriodStartDate))) EndDay
                , SUM(CASE WHEN bd.ZoneNumberId = 1 THEN bd.Consumption END) Value1
                , SUM(CASE WHEN bd.ZoneNumberId = 9 THEN bd.Consumption END) Value21
                , SUM(CASE WHEN bd.ZoneNumberId = 10 THEN bd.Consumption END) Value22
                , SUM(CASE WHEN bd.ZoneNumberId = 11 THEN bd.Consumption END) Value31
                , SUM(CASE WHEN bd.ZoneNumberId = 12 THEN bd.Consumption END) Value32
                , SUM(CASE WHEN bd.ZoneNumberId = 13 THEN bd.Consumption END) Value33
                FROM BILL b, BillDetails bd WHERE b.CODE = bd.BillId AND b.INVSTATUSCODE != 2
                AND b.ServiceProviderId in (1,2) AND bd.PeriodStartDate>='1.1.19' AND b.PAYMENTTYPECODE = 0 
and b.PERIODREFCODE<=(select max(cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0)
                GROUP BY b.RECORDPONTRFCODE, bd.PeriodStartDate) t
                WHERE COALESCE(t.Value1,0)>=0 AND COALESCE(t.Value21,0)>=0 AND COALESCE(t.Value22,0)>=0 AND COALESCE(t.Value31,0)>=0 AND COALESCE(t.Value32,0)>=0 AND COALESCE(t.Value33,0)>=0";

        public static string SelectCitizensQuery = @"SELECT * FROM (
                SELECT r.code ClientId, p.NAME, p.SURNAME fam, p.PATRONIMIC otch, 1 vlad, TRIM(p.TAXCODE) TaxCode, 
                  coalesce(p.PASSPORTDATSERIA,'')+COALESCE(p.PSPRTDTNUMBERGEN,'') Passport, p.PSPRTDTISSUEDATE PassportIssueDate, p.PASSPORTDTISSUER PassportIssuer, 1 DocType
                  FROM ActualContract ac, ContractsHistory ch, RECORDPOINT r, PERSON p
                  WHERE ac.RecordpointId = r.CODE AND ac.ContractId = ch.Id AND ch.PersonId = p.CODE AND r.ServiceProviderId in (1,2) AND COALESCE(r.ISTECHNICAL,0)!=1
                  UNION SELECT b.RECORDPONTRFCODE, '', b.FIO, '', 0,'', b.CERTIFICATENUMBR, b.CERTIFICATEISSDT, b.CERTIFICATISSDBY, 8 
                  FROM BENEFICIARY b WHERE COALESCE(b.ENDDATE, DATEADD(DAY, 1, GETDATE()))>=GETDATE()) t";

        //public static string SelectPaymentsQuery = @"SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank FROM PaymentBatch pb, PaymentDocument pd, PAYMENTCHANNEL p 
        //        WHERE pb.id = pd.BatchId AND pb.ServiceProviderId=1 AND pd.RecordpointId IS NOT NULL
        //        AND  p.Code = pb.PaymentChannelId AND COALESCE(p.TypeCode,0) IN (0,2) AND p.Name NOT LIKE '%Постанова КМУ № 64%' AND StatusId=1 
        //        GROUP BY recordpointId, pd.PayDate HAVING SUM(pd.sum)>0";

        // 25.02.2024 Додано корегування в оплатах
        public static string SelectPaymentsQuery = @"with
tpay as
(
                SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank, pd.id as pdid
                FROM PaymentDocument pd
                  join PaymentBatch pb on pb.id = pd.BatchId
                  join PAYMENTCHANNEL p on p.Code = pb.PaymentChannelId
                                WHERE pb.ServiceProviderId= 1
                                AND pd.RecordpointId IS NOT NULL
                                AND COALESCE(p.TypeCode,0) IN (0,2,3)
and pd.PeriodId<=(select max(cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0 and p.startdate>='01.01.2019')
                                AND p.Name NOT LIKE '%Постанова КМУ № 64%' AND StatusId = 1
                                
                             GROUP BY recordpointId, pd.PayDate, pd.id HAVING SUM(pd.sum)>0 
                 union all  
                                 SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank, pd.id as pdid
                FROM PaymentDocument pd
                left join PaymentBatch pb on pb.id = pd.BatchId
                left join PAYMENTCHANNEL p on p.Code = pb.PaymentChannelId
                               WHERE
                                COALESCE(p.TypeCode,0) IN(0,2,3)
                                and pd.ServiceProviderId= 1
                                AND StatusId = 1
and pd.TypeId in (1,3,5,6) 
                                --and pd.PayDate>='01.01.2019'
and pd.PeriodId in (select (cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0 and p.startdate>='01.01.2019')
                                GROUP BY pd.recordpointId, pd.PayDate, pd.id
                                HAVING SUM(pd.sum)!=0           
)  
--select sum(summpay) from tpay
  
,tcorr as
(
                SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank, pd.id as pdid
                FROM PaymentDocument pd
                left join PaymentBatch pb on pb.id = pd.BatchId
                left join PAYMENTCHANNEL p on p.Code = pb.PaymentChannelId
                               WHERE
                                COALESCE(p.TypeCode,0) IN(0,2,3)
                                and pd.ServiceProviderId= 1
                                AND StatusId = 1
                                and pd.TypeId in (1,3,5,6) 
                                --and pd.PayDate>='01.01.2019'
and pd.PeriodId in (select (cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0 and p.startdate>='01.01.2019')
                                GROUP BY pd.recordpointId, pd.PayDate, pd.id
                                HAVING SUM(pd.sum)<0
)
,tcorrdel(clientId,tpaydatebank, tpaysummpay,tpaypdid,tcorrdatebank,tcorrsummpay, tcorrpdid) as
(
select 
tpay.clientId as clientId
,tpay.datebank as tpaydatebank
,tpay.summpay as tpaysummpay
,tpay.pdid as tpaypdid
,tcorr.datebank as tcorrdatebank
,tcorr.summpay as tcorrsummpay
,tcorr.pdid as tcorrpdid
from tpay
join tcorr on tcorr.clientId=tpay.clientId 
where 
abs(tcorr.summpay)=tpay.summpay
and tcorr.datebank=tpay.datebank

)
,
tcorrnopay(clientId,summpay,datebank,pdid) as
(
select 
*
from tcorr
where tcorr.pdid not in (select tcorrpdid from tcorrdel)
)

select
tpay.clientId
,case when tpay.pdid in  (select pdid from tcorrnopay) then 0 else tpay.summpay end as summpay
,tpay.datebank
from tpay
where tpay.pdid not in (select tpaypdid from tcorrdel)  
and tpay.pdid not in (select tcorrpdid from tcorrdel)";




        public static string SelectSubsidyQuery = @"SELECT ClientId, Datebank, SUM(Summpay) Summpay FROM (
                SELECT b.RECORDPONTRFCODE ClientId, b.SUBSIDY Summpay, b.ENDDATE Datebank  FROM BILL b 
                WHERE b.INVSTATUSCODE<>2 AND b.ServiceProviderId in (1,2) AND COALESCE(b.SUBSIDY,0)<>0 
                UNION ALL SELECT pd.RecordpointId, pd.sum, CAST(PayDate AS DATETIME2) FROM PaymentBatch pb, PaymentDocument pd, PAYMENTCHANNEL p WHERE pb.id = pd.BatchId AND pb.ServiceProviderId in (1,2) 
                AND pd.sum<>0 AND p.Name LIKE '%субсидія%' AND Typecode=3 AND p.Code = pb.PaymentChannelId AND StatusId=1) t GROUP BY ClientId, Datebank";

        public const string SelectPay375Query = @"SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank FROM PaymentBatch pb, PaymentDocument pd, PAYMENTCHANNEL p 
                WHERE pb.id = pd.BatchId AND pb.ServiceProviderId in (1,2) 
                AND  p.Code = pb.PaymentChannelId AND p.TypeCode=1 AND StatusId=1 
and pd.PeriodId<=(select max(cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0)
GROUP BY recordpointId, pd.PayDate HAVING SUM(pd.sum)>0";

        public const string SelectPay64Query = @"SELECT recordpointId clientId, SUM(pd.sum) summpay, pd.PayDate datebank FROM PaymentBatch pb, PaymentDocument pd, PAYMENTCHANNEL p 
                WHERE pb.id = pd.BatchId AND pb.ServiceProviderId in (1,2) AND  p.Code = pb.PaymentChannelId AND StatusId=1 AND p.Name LIKE '%Постанова КМУ № 64%' 
and pd.PeriodId in (select (cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0 and p.startdate>='01.01.2019')
GROUP BY recordpointId, pd.PayDate";

        public const string SelectMonetizedDiscounts = @"SELECT pd.RecordpointId ClientId, SUM(pd.sum) summpay, PayDate Datebank FROM PaymentBatch pb, PaymentDocument pd, PAYMENTCHANNEL p WHERE pb.id = pd.BatchId 
                AND pb.ServiceProviderId in (1,2) AND pd.sum<>0 AND p.Name LIKE '%Пільга%' AND Typecode=3 AND p.Code = pb.PaymentChannelId AND StatusId=1 
and pd.PeriodId in (select (cp.code) from currentperiod cp join period p on p.code = cp.periodcode where cp.ISOPENED=0 and p.startdate>='01.01.2019')
GROUP BY pd.RecordpointId, pd.PayDate";

        public const string SelectDebtRestructingPlansQuery = @"SELECT drs.RecordpointId clientId, drs.Sum debt, debtend.dateend, DATEADD(DAY, 1, EOMONTH(drs.AddedAt)) datebegin FROM (
                SELECT drse.DebtRepaymentScheduleId, MAX(DATEADD(DAY, 1, EOMONTH(drse.DueDate))) dateend FROM usp.DebtRepaymentSchedulesEntry drse 
                GROUP BY drse.DebtRepaymentScheduleId HAVING MAX(drse.DueDate)>GETDATE()) debtend
                JOIN usp.DebtRepaymentSchedules drs ON debtend.DebtRepaymentScheduleId=drs.Id";
    }
}