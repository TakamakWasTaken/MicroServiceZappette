using EntrepotService;
using ScanningTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanningTool.Interfaces
{
    interface IScanningTool
    {
        void Scan(EntrepotService.Product p);
        void AddProduct(EntrepotService.Product p);
    }
}
