using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_1
{ 
class MobilePhones : storeInventory
{
    public MobilePhones(string assetID, string modelName, string branchLocations, DateTime purchaseDate, int price) : base(assetID, modelName, branchLocations, purchaseDate, price)
    {
        AssetID = assetID;
        ModelName = modelName;
            BranchLocations = branchLocations;
            PurchaseDate = purchaseDate;
        Price = price;
    }
}
}
