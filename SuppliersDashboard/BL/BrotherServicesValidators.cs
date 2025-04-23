using RestSharp.Validation;
using ScoposERB.DTOS;
using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;

namespace ScoposERB.BL
{
    public class BrotherServicesValidators
    {

        
        public int  GetServiceState (List<service> Services)
        {
            int status = 1; 
            foreach (service S in Services)
            {
                //if (true)
                //{
                //    bool iscomplete = (ValidateStringValues(S.comment));
                //    if (iscomplete == false)
                //        status = 0;
                //}
                if(S.ID == 92) // Freight
                {
                    bool iscomplete = (ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo) 
                        && ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)&& ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.grossWeight)&&ValidateStringValues(S.deliveryDate)
                        && ValidateStringValues(S.BL_AWB_No) &&ValidateStringValues(S.incoterms)
                        
                        );
                    if (iscomplete == false)
                        status = 0; 
                }
                else if(S.ID == 93) // Cleareance 
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType) && ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.grossWeight) && ValidateStringValues(S.deliveryDate) 
                        && ValidateStringValues(S.kindOfCargo)
                        && ValidateStringValues(S.BL_AWB_No)
                    //    && ValidateStringValues(S.point) 
                        );
                    if (iscomplete == false)
                        status = 0;
                }
                else if(S.ID == 94) // Free Hand  
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType) 
                        && ValidateStringValues(S.shipmentFrom)&& ValidateStringValues(S.shipmentTo) 
                        && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate) 
                         && ValidateStringValues(S.BL_AWB_No) && ValidateStringValues(S.incoterms)


                        );
                    if (iscomplete == false)
                        status = 0;
                }
                else if(S.ID == 95) // WareHousing
                {
                    bool iscomplete = (
                        ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate)  
                        && ValidateStringValues(S.WhStartDate) && ValidateStringValues(S.WhEndDate) 
                        && ValidateStringValues(S.WhPoint)
                        && ValidateStringValues(S.kindOfCargo)
                        );
                    if (iscomplete == false)
                        status = 0;
                } 
                 else if(S.ID == 96) // Insurance
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        && ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                        && ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.insurancePolicyNo)
                        && ValidateStringValues(S.cargoValue)

                        );
                    if (iscomplete == false)
                        status = 0;
                } 
                else if(S.ID == 97) // ACID
                {
                    bool iscomplete = (
                        ValidateStringValues(S.ACIDNumber)
                       && ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        );
                    if (iscomplete == false)
                        status = 0;
                }else if(S.ID == 98) // EGYCA
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        && ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                          && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                           && ValidateStringValues(S.BL_AWB_No)

                          );


                    if (iscomplete == false)
                        status = 0;
                }else if(S.ID == 99) // DoMESTIC
                {
                    bool iscomplete = (
                       ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                          && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate)
                        && ValidateStringValues(S.kindOfCargo)
                        && ValidateStringValues(S.noOfTruck)
                        && ValidateStringValues(S.typeOfTruck)

                          );


                    if (iscomplete == false)
                        status = 0;
                }
                

            }
            return status;
        }
        public int  GetServiceState2 (List<BRO_RequestServices_DTO> Services)
        {
            int status = 1; 
            foreach (BRO_RequestServices_DTO S in Services)
            {

                //if (true)
                //{
                //    bool iscomplete = (ValidateStringValues(S.comment));
                //    if (iscomplete == false)
                //        status = 0;
                //}
                
                if(S.ServiceID == 92) // Freight
                {
                    bool iscomplete = (ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo) 
                        && ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)&& ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.grossWeight)&&ValidateStringValues(S.deliveryDate.ToString())
                         && ValidateStringValues(S.BL_AWB_No) && ValidateStringValues(S.incoterms)


                        );
                    if (iscomplete == false)
                        status = 0; 
                }
                else if(S.ServiceID == 93) // Cleareance 
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType) && ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.grossWeight) && ValidateStringValues(S.deliveryDate.ToString()) && ValidateStringValues(S.kindOfCargo)
                         && ValidateStringValues(S.BL_AWB_No)

                    //    && ValidateStringValues(S.point) 
                        );
                    if (iscomplete == false)
                        status = 0;
                }
                else if(S.ServiceID == 94) // Free Hand  
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType) 
                        && ValidateStringValues(S.shipmentFrom)&& ValidateStringValues(S.shipmentTo) 
                        && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate.ToString()) 
                         && ValidateStringValues(S.BL_AWB_No) && ValidateStringValues(S.incoterms)


                        );
                    if (iscomplete == false)
                        status = 0;
                }
                else if(S.ServiceID == 95) // WareHousing
                {
                    bool iscomplete = (
                        ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate.ToString())  
                        && ValidateStringValues(S.WhStartDate.ToString()) && ValidateStringValues(S.WhEndDate.ToString()) 
                        && ValidateStringValues(S.WhPoint)
                        && ValidateStringValues(S.kindOfCargo)
                        );
                    if (iscomplete == false)
                        status = 0;
                } 
                 else if(S.ServiceID == 96) // Insurance
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        && ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                        && ValidateStringValues(S.cargoVolume)
                        && ValidateStringValues(S.insurancePolicyNo)
                        && ValidateStringValues(S.cargoValue)

                        );
                    if (iscomplete == false)
                        status = 0;
                } 
                else if(S.ServiceID == 97) // ACID
                {
                    bool iscomplete = (
                        ValidateStringValues(S.ACIDNumber)
                       && ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        );
                    if (iscomplete == false)
                        status = 0;
                }else if(S.ServiceID == 98) // EGYCA
                {
                    bool iscomplete = (
                        ValidateStringValues(S.shipMethod) && ValidateStringValues(S.shipType)
                        && ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                          && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                            && ValidateStringValues(S.BL_AWB_No)
                          );


                    if (iscomplete == false)
                        status = 0;
                }else if(S.ServiceID == 99) // DoMESTIC
                {
                    bool iscomplete = (
                       ValidateStringValues(S.shipmentFrom) && ValidateStringValues(S.shipmentTo)
                          && ValidateStringValues(S.cargoVolume) && ValidateStringValues(S.grossWeight)
                        && ValidateStringValues(S.deliveryDate.ToString())
                        && ValidateStringValues(S.kindOfCargo)
                        && ValidateStringValues(S.noOfTruck)
                        && ValidateStringValues(S.typeOfTruck)

                          );


                    if (iscomplete == false)
                        status = 0;
                }


            }
            return status;
        }
        /////////////////
        ///
        public int GetReuestHeaderState(string comment, string additionalFile, string AdditionalCharges, string AdditionalExpenses ,string shipcostdescrip , string shipcostfile , string shipofferdesc , string shipofferfile , bool HasFreightService = false)
        {
            int status = 1;
        
                if (!ValidateStringValues(comment))
                status = 0;

            if (HasFreightService)
            {
                // if(! ValidateStringValues(AdditionalCharges))
                //    status = 0;

                //if ( !ValidateStringValues(AdditionalExpenses))
                //    status = 0;
                if (!ValidateStringValues(shipcostdescrip))
                    status = 0; 
                if (!ValidateStringValues(shipofferdesc))
                    status = 0;
                 if (!ValidateStringValues(shipcostfile))
                    status = 0; 
                if (!ValidateStringValues(shipofferfile))
                    status = 0;

            }


            return status;

        }
        



       public string GetValidatingMessage(List<BRO_RequestServices_DTO> Services , string comment, string additionalFile, string AdditionalCharges, string AdditionalExpenses , string shipcostdescrip, string shipcostfile, string shipofferdesc, string shipofferfile)
        {
            string  Message = "";
            //if (!ValidateStringValues(additionalFile))
            //    Message += " Additional File Required ! *";
            //if (!ValidateStringValues(comment))
            //    Message += " comment Required ! *";
            if (Services.Any(x => x.ServiceID == 92))
            {
                // If Has Freight
                //if (!ValidateStringValues(AdditionalCharges))
                //    Message += " Additional Charges File Required With Freight Service !  *";
                //if (!ValidateStringValues(AdditionalExpenses))
                //    Message += " Additional Expenses File Required With Freight Service  ! *";

                if (!ValidateStringValues(shipcostdescrip))
                    Message += "  Shipping Cost description reqired With Freight Service  ! *";

                if (!ValidateStringValues(shipofferdesc))
                    Message += "  Shipping offer description reqired With Freight Service  ! *";

                if (!ValidateStringValues(shipcostfile))
                    Message += "  Shipping Cost Attachment File reqired With Freight Service  ! *";

                if (!ValidateStringValues(shipofferfile))
                    Message += "  Shipping offer Attachment File reqired With Freight Service  ! *";

               
            }


            foreach (BRO_RequestServices_DTO S in Services)
            {

                if (S.ServiceID == 92) // Freight
                {
                   if(! ValidateStringValues(S.shipmentFrom))
                        Message += " Shipment From In Freight Service *";
                    if (! ValidateStringValues(S.shipmentTo))
                        Message += " Shipment To  In Freight Service *";
                   if(! ValidateStringValues(S.shipMethod) )
                        Message += " Shipment Method In Freight Service *";
                   if(! ValidateStringValues(S.shipType) )
                       Message += " Shipment Type In Freight Service *";
                   if(! ValidateStringValues(S.cargoVolume))
                       Message += " Cargo Volume In Freight Service *";
                   if(! ValidateStringValues(S.grossWeight)  )
                       Message += " Gross Weight In Freight Service *";
                   if(! ValidateStringValues(S.deliveryDate.ToString()))
                       Message += "Delivery Date  In Freight Service *";
                   if(! ValidateStringValues(S.BL_AWB_No)  )
                        Message += " BL_AWB_No In Freight Service *";
                    if (! ValidateStringValues(S.incoterms))
                        Message += " Incomters In Freight Service *";
                     if (! ValidateStringValues(S.comment))
                        Message += " comment In Freight Service *";


                }
                else if (S.ServiceID == 93) // Cleareance 
                {


                    if (!ValidateStringValues(S.shipMethod))
                        Message += "Shipment Method In Clearance Service *";
                        if (!ValidateStringValues(S.shipType))
                        Message += "Shipment Type In Clearance Service *";
                        if (!ValidateStringValues(S.cargoVolume))
                        Message += "Cargo Volume In Clearance Service *";
                        if (!ValidateStringValues(S.grossWeight))
                        Message += "Gross Weight In Clearance Service *";
                        if (!ValidateStringValues(S.deliveryDate.ToString()))
                        Message += "Delivery Date In Clearance Service *";
                        if (!ValidateStringValues(S.kindOfCargo))
                        Message += "Kind Of Cargo In Clearance Service *";
                        if(!ValidateStringValues(S.BL_AWB_No))
                        Message += " BL_AWB_No In Clearance Service *";

                        if(!ValidateStringValues(S.comment))
                        Message += " comment Clearance Service *";


                   
                }
                else if (S.ServiceID == 94) // Free Hand  
                {

                    if (!ValidateStringValues(S.shipMethod))
                        Message += "Ship Method In Free Hand Service *";
                        if (!ValidateStringValues(S.shipType))
                        Message += "Ship Type In Free Hand Service *";
                        if (!ValidateStringValues(S.shipmentFrom))
                        Message += "Ship From In Free Hand Service *";
                        if (!ValidateStringValues(S.shipmentTo))
                        Message += "Ship To In Free Hand Service *";
                        if (!ValidateStringValues(S.cargoVolume))
                        Message += "Cargo Volume  In Free Hand Service *";
                        if (!ValidateStringValues(S.grossWeight))
                        Message += "Gross Weight In Free Hand Service *";
                        if (!ValidateStringValues(S.deliveryDate.ToString()))
                        Message += "Delivery Date In Free Hand Service *";
                        if (!ValidateStringValues(S.BL_AWB_No))
                        Message += " BL_AWB_No In Free Hand Service *";
                        if (!ValidateStringValues(S.incoterms))
                        Message += "Incomters  In Free Hand Service *";
                        if (!ValidateStringValues(S.comment))
                        Message += "comment  In Free Hand Service *";


                    
                }
                else if (S.ServiceID == 95) // WareHousing
                {
                  
                        if(!ValidateStringValues(S.cargoVolume)                   )
                        Message += "Cargo Volume In WareHousing Service *";
                        if(!ValidateStringValues(S.grossWeight)                   )
                        Message += "Gross Weigth In WareHousing Service *";
                        if(!ValidateStringValues(S.deliveryDate.ToString())       )
                           Message += "Delivery Date In WareHousing Service *";
                        if(!ValidateStringValues(S.WhStartDate.ToString())        )
                                    Message += "WareHouse Start Date  In WareHousing Service *";
                        if(!ValidateStringValues(S.WhEndDate.ToString())          )
                                        Message += "Ware House End Date In WareHousing Service *";
                        if(!ValidateStringValues(S.WhPoint)                       )
                                            Message += "WareHouse Point In WareHousing Service *";
                    if (!ValidateStringValues(S.kindOfCargo))
                        Message += "Kind Of Kargo  In WareHousing Service *";
                         if (!ValidateStringValues(S.comment))
                        Message += "comment  In WareHousing Service *";
                       
                }
                else if (S.ServiceID == 96) // Insurance
                {
                    
                       if(! ValidateStringValues(S.shipMethod)              )
                        Message += "Ship Method In Insurance Service *";
                       if(! ValidateStringValues(S.shipType)                )
                            Message += "Ship Type In Insurance Service *";
                       if(! ValidateStringValues(S.shipmentFrom)            )
                            Message +="Shipment From  In Insurance Service *";
                       if(! ValidateStringValues(S.shipmentTo)              )
                            Message +="Shipment To  In Insurance Service *";
                       if(! ValidateStringValues(S.cargoVolume)             )
                           Message +="Cargo Volume  In Insurance Service *";
                       if(! ValidateStringValues(S.insurancePolicyNo)       )
                         Message +="Insurance policy Number  In Insurance Service *";
                    if (!ValidateStringValues(S.cargoValue))
                        Message += "Cargo Value  In Insurance Service *";
                      if (!ValidateStringValues(S.comment))
                        Message += "comment  In Insurance Service *";

                       
                }
                else if (S.ServiceID == 97) // ACID
                {

                    if (!ValidateStringValues(S.ACIDNumber))
                        Message += "ACID Number  In ACID Service *";
                       if(! ValidateStringValues(S.shipMethod)   )
                            Message += "Shipment Method  In ACID Service *";
                       if(! ValidateStringValues(S.shipType)     )
                                Message += "Shipment Type In ACID Service *";
                           if(! ValidateStringValues(S.comment)     )
                                Message += "comment In ACID Service *";
                       
                }
                else if (S.ServiceID == 98) // EGYCA
                {

                    if (!ValidateStringValues(S.shipMethod))
                        Message += "Shipment Method In Egyca Service *";
                       if(! ValidateStringValues(S.shipType)        )
                        Message += "Shipment Type  In Egyca Service *";

                    if (! ValidateStringValues(S.shipmentFrom)    )
                        Message += "Shipent From  In Egyca Service *";

                       if(! ValidateStringValues(S.shipmentTo)      )
                        Message += "Shipment To  In Egyca Service *";

                       if(! ValidateStringValues(S.cargoVolume)     )
                        Message += "Cargo Volume  In Egyca Service *";

                       if(! ValidateStringValues(S.grossWeight)     )
                        Message += "Gross Weight  In Egyca Service *";

                       if(! ValidateStringValues(S.BL_AWB_No)       )
                        Message += "BL_AWB_No In Egyca Service *";
                        if(! ValidateStringValues(S.comment)       )
                        Message += "comment In Egyca Service *";

                }
                else if (S.ServiceID == 99) // DoMESTIC
                {

                      if(!ValidateStringValues(S.shipmentFrom)                  )
                        Message+= "Shipment From  In Domestic Service *";
                      if(!ValidateStringValues(S.shipmentTo)                    )
                            Message+= "Shipment To In Domestic Service *";
                      if(!ValidateStringValues(S.cargoVolume)                   )
                                Message+= "Cargo Volume  In Domestic Service *";
                      if(!ValidateStringValues(S.grossWeight)                   )
                                    Message+= "Gross Weight  In Domestic Service *";
                      if(!ValidateStringValues(S.deliveryDate.ToString())       )
                                        Message+= "Delivery Date  In Domestic Service *";
                      if(!ValidateStringValues(S.kindOfCargo)                   )
                                            Message+= "Kind Of Cargo  In Domestic Service *";
                      if(!ValidateStringValues(S.noOfTruck)                     )
                                                Message+= "No of truck  In Domestic Service *";
                    if (!ValidateStringValues(S.typeOfTruck))
                        Message += "Type Of Truck  In Domestic Service *";
                       if (!ValidateStringValues(S.comment))
                        Message += "comment  In Domestic Service *";

                         

                   
                }


            }

            return Message;
        }
        public bool ValidateStringValues(string Val)
        {
            if (Val == null)
                return false;
            if(Val.Trim() == "")
                return false;
            return true;
        }
    
        public bool ValidatedecimalValues(decimal Val)
        {  
            if (Val <= 0 )
                return false;
            return true;
        } 
        public bool ValidateIntValues(int Val)
        {  
            if (Val <= 0 )
                return false;
            return true;
        }

    }
}