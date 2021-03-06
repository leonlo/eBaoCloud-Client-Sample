﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using ebaoCloud cmi client namespace
using com.ebaocloud.client.thai.seg.cmi.api;
using com.ebaocloud.client.thai.seg.cmi.parameters;
using com.ebaocloud.client.thai.seg.cmi.response;

namespace com.ebao.gs.ebaocloud.sea.seg.cmi.sample
{
    public class Calculate
    {
        public void CalculateAction()
        {
            PolicyService service = new PolicyServiceImpl();
            LoginResp resp = service.Login(Login.sampleUserName, Login.samplePassword);

            var calculationParams = new CalculationParams();
            calculationParams.effectiveDate = DateTime.Now.ToLocalTime();
            calculationParams.expireDate = DateTime.Now.AddYears(1).ToLocalTime();
            calculationParams.proposalDate = DateTime.Now.ToLocalTime();
            calculationParams.productCode = "CMI";
            calculationParams.vehicleUsage = VehicleUsage.PRIVATE;

            CalculationResp calcResp = service.Calculate(resp.token, calculationParams);
            if (calcResp.success)
            {
                Console.WriteLine("Calculate succcess: true");
            }
            else
            {
                Console.WriteLine("Calculate succcess: false" + "\nMessage:" + calcResp.errorMessage);
            }
        }
    }
}
