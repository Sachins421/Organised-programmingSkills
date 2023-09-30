using Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
using Domain.Mapping.Dto;
using Model.Data.Models.ProductionLineRequest;
using Model.Data.Repositries;
using model = Model.Data.Models.ProductionLineRequest;

namespace Domain.Mapping.GlassRequestDto
{
#pragma warning disable CS8601
    public static class GlassRequestExtension
    {
        public static GlassProductionLineRequest ToModel(this GlassRequest glassRequest)
        {
            return new model.GlassProductionLineRequest
            {
                Id = new Id
                {
                    id = glassRequest.SourceInformation.Id,
                    LineNo = glassRequest.SourceInformation.LineNo,
                    SalesChannel = glassRequest.SourceInformation.SalesChannel,
                    SalesCountryISO = glassRequest.SourceInformation.SalesCountryISO
                },

                Execution = new model.Execution
                {
                    TimeStamp = glassRequest.TimeStamp,
                    Source = glassRequest.Source,
                    GlassRequestEntryNo = glassRequest.BaseData.GlassRequestEntryNo,

                    GlassRequest = new model.GlassRequests.GlassRequest
                    {
                        GlassColors = glassRequest.GlassColor?.Select(x => new model.GlassRequests.GlassColor
                        {
                            Color = x.Color,
                            GlassColorPattern = x.GlassColorPattern?.Select(gcr => new model.GlassRequests.GlassColorPattern
                            {
                                MirroredGlass = gcr.MirroredGlass,
                            }).ToList(),
                            Manufacturer = x.Manufacturer,
                            TingePercentage = x.TingePercentage,
                            GradientPercentage = x.GradientPercentage
                        }).ToList(),

                        OrderLines = glassRequest.OrderLines.Select(ol => new model.GlassRequests.OrderLine
                        {
                            ItemCategory = ol.ItemCategory,
                            Type = ol.type,
                            No = ol.No,
                            LineNo = ol.LineNo,
                            Quantity = ol.Quantity
                        }).ToList(),

                        Availabilities = glassRequest.Availabilities.Select(av => new model.GlassRequests.Availability
                        {
                            Manufacturer = av.Manufacturer,
                            Location = av.Location,
                            Available = av.Available,
                        }).ToList(),

                        Item = new model.GlassRequests.Item
                        {
                            Aspheric = glassRequest.Item.Aspheric,
                            EdgeThickness = glassRequest.Item.EdgeThickness,
                            FrontCurve = glassRequest.Item.FrontCurve,
                            FrontMaterial = glassRequest.Item.FrontMaterial,
                            GlassWidth = glassRequest.Item.GlassWidth,
                            BarWidth = glassRequest.Item.BarWidth,
                            Glazable = glassRequest.Item.Glazable,
                            ItemCategory = glassRequest.Item.ItemCategory,
                            ManufactureMethod = glassRequest.Item.ManufactureMethod,
                            ItemNo = glassRequest.Item.ItemNo,
                            Description = glassRequest.Item.Description,
                            PhysicalFrameType = glassRequest.Item.PhysicalFrameType,
                        },
                        BaseData = new model.GlassRequests.BaseData
                        {
                            BarcodePreManufacturing = glassRequest.BaseData.BarcodePreManufacturing,
                            GlassManufacturerVendorNo = glassRequest.BaseData.GlassManufacturerVendorNo,
                            FreeGlassThickness = glassRequest.BaseData.FreeGlassThickness,
                            GlassRequestEntryNo = glassRequest.BaseData.GlassRequestEntryNo,
                            ShippingAgent = glassRequest.BaseData.ShippingAgent,
                            ShopInShop = glassRequest.BaseData.ShopInShop,
                            HasSpecialInvReference = glassRequest.BaseData.HasSpecialInvReference,
                            RepairShop = glassRequest.BaseData.RepairShop,
                            ManufactureMethod = glassRequest.BaseData.ManufactureMethod,
                            Company = glassRequest.SourceInformation.Company,
                            SalesLanguage = glassRequest.SourceInformation.SalesLanguage,
                            SalesChannelERP = glassRequest.SourceInformation.SalesChannelERP,
                            IsNordicsOrder = glassRequest.BaseData.IsNordicsOrder,
                            FinalSelectedManufactureMethod = glassRequest.BaseData.FinalSelectedManufactureMethod
                        },
                        GlassParameter = new model.GlassRequests.GlassParameter
                        {
                            CorrectionValue = new model.GlassRequests.CorrectionValue
                            {
                                Diameter = glassRequest.GlasParameter.CorrectionValue.Diameter,
                                PDL = glassRequest.GlasParameter.CorrectionValue.PDL,
                                PDR = glassRequest.GlasParameter.CorrectionValue.PDR,
                                PolarizedGlass = glassRequest.GlasParameter.CorrectionValue.PolarizedGlass,
                                AddL = glassRequest.GlasParameter.CorrectionValue.AddL,
                                AddR = glassRequest.GlasParameter.CorrectionValue.AddR,
                                AxisL = glassRequest.GlasParameter.CorrectionValue.AxisL,
                                AxisR = glassRequest.GlasParameter.CorrectionValue.AxisR,
                                BasicCurve = glassRequest.GlasParameter.CorrectionValue.BasicCurve,
                                CylinderL = glassRequest.GlasParameter.CorrectionValue.CylinderL,
                                CylinderR = glassRequest.GlasParameter.CorrectionValue.CylinderR,
                                GlassThickness = glassRequest.GlasParameter.CorrectionValue.GlassThickness,
                                GrindL = glassRequest.GlasParameter.CorrectionValue.GrindL,
                                GrindR = glassRequest.GlasParameter.CorrectionValue.GrindR,
                                Name = glassRequest.GlasParameter.CorrectionValue.Name,
                                SphereL = glassRequest.GlasParameter.CorrectionValue.SphereL,
                                SphereR = glassRequest.GlasParameter.CorrectionValue.SphereR,
                                Type = glassRequest.GlasParameter.CorrectionValue.Type
                            },

                            PackageValues = new model.GlassRequests.PackageValues
                            {
                                DigitalRelax = glassRequest.GlasParameter.PackageValues.DigitalRelax,
                                FieldofVision = glassRequest.GlasParameter.PackageValues.FieldofVision,
                                GlasThicknessForPrice = glassRequest.GlasParameter.PackageValues.GlasThicknessForPrice,
                                GlassPackageType = glassRequest.GlasParameter.PackageValues.GlassPackageType,
                                GlassType = glassRequest.GlasParameter.PackageValues.GlassType,
                                //GlasThickness = glassRequest.GlasParameter.PackageValues.GlasThickness,
                                GradientPercentage = glassRequest.GlasParameter.PackageValues.GradientPercentage,
                                InnerProgression = glassRequest.GlasParameter.PackageValues.InnerProgression,
                                LotusEffect = glassRequest.GlasParameter.PackageValues.LotusEffect,
                                Mirrored = glassRequest.GlasParameter.PackageValues.Mirrored,
                                Polished = glassRequest.GlasParameter.PackageValues.Polished,
                                TingeColor = glassRequest.GlasParameter.PackageValues.TingeColor,
                                TingePercentage = glassRequest.GlasParameter.PackageValues.TingePercentage,
                                TingeType = glassRequest.GlasParameter.PackageValues.TingeType,
                                SunGlassTypePhoto = glassRequest.GlasParameter.PackageValues.SunGlassTypePhoto,
                                //ChannelLength = glassRequest.GlasParameter.PackageValues.ChannelLength,
                                //StandardTinge = glassRequest.GlasParameter.PackageValues.StandardTinge,
                                //Gradient = glassRequest.GlasParameter.PackageValues.Gradient,
                                Filter = glassRequest.GlasParameter.PackageValues.Filter,
                                PolarizedGlass = glassRequest.GlasParameter.PackageValues.PolarizedGlass,
                            }
                        },

                        TracerData = new model.GlassRequests.TracerData
                        {
                            DistanceBetweenLenses = glassRequest.TracerData.DistanceBetweenLenses,
                            GlassTracingData = glassRequest.TracerData.GlassTracingData,
                            EntryNo = glassRequest.TracerData.EntryNo
                        },

                        Counter = glassRequest.Counter,
                        MessageID = glassRequest.MessageID,
                        Source = glassRequest.Source,
                        TimeStamp = glassRequest.TimeStamp,
                    }
                } 

            };
        }
    }
}