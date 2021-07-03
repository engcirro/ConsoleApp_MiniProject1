using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_1
{
	class storeInventory
	{       
			public storeInventory(string assetID, string modelName, string branchLocations,  DateTime purchaseDate, int price)
			{
					AssetID = assetID;
					ModelName = modelName;
					BranchLocations = branchLocations;
			   PurchaseDate = purchaseDate;
					Price = price;


			}

			public string AssetID { get; set; }
			public string ModelName { get; set; }
			public DateTime PurchaseDate { get; set; }
			public int Price { get; set; }
		public string BranchLocations { get; set; }
		public string BranchCurrency { get; set; }

	}
	}

