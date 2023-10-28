//using Model.Data.Models.ManufacturerSetup;
using Amazon.Runtime.Internal.Util;
using System.Net.Http.Headers;
using model = Model.Data.Models.ManufacturerSetup;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public static class SetupToModel
    {
        public static model.MfrSetup ToModel(this ManufactuerSetup manufactuerSetup)
        {
            return new model.MfrSetup
            {
                BaseData = new model.BaseData
                {
                    VendorNo = manufactuerSetup.BaseData.VendorNo,
                    GlassCatalogueName = manufactuerSetup.BaseData.GlassCatalogueName,
                    Name = manufactuerSetup.BaseData.Name,
                    GlassDb = manufactuerSetup.BaseData.GlassDb,
                    GlassRequestCleanMultifokalInnenProgressive = manufactuerSetup.BaseData.GlassRequestCleanMultifokalInnenProgressive,
                    GlassRequestCleanValue = manufactuerSetup.BaseData.GlassRequestCleanValue,
                    ManufactureMethod = manufactuerSetup.BaseData.ManufactureMethod,
                    OutSourcedProduction = manufactuerSetup.BaseData.OutSourcedProduction,
                },
                ServicePrices = manufactuerSetup.ServicePrices.Select(s => new model.ServicePrice
                {
                    ServiceType = s.ServiceType,
                    PhysicalFrameType = s.PhysicalFrameType,
                    DirectUnitCost = s.DirectUnitCost,
                    ManufactureMethod = s.ManufactureMethod
                }).ToArray(),

                AutoselectFilterChecks = new model.AutoselectFilterChecks
                {
                    SphereLeftFilter = new model.GlassThicknessMinMax
                    {
                        Aspheric = manufactuerSetup.AutoselectFilterChecks.SphereLeftFilter.Aspheric,
                        glassPackageType = manufactuerSetup.AutoselectFilterChecks.SphereLeftFilter.glassPackageType,
                        GlassThickness = manufactuerSetup.AutoselectFilterChecks.SphereLeftFilter.GlassThickness,
                        MaxValue = manufactuerSetup.AutoselectFilterChecks.SphereLeftFilter.MaxValue,
                        MinValue = manufactuerSetup.AutoselectFilterChecks.SphereLeftFilter.MinValue,
                    },
                    SphereRightFilter = new model.GlassThicknessMinMax
                    {
                        Aspheric = manufactuerSetup.AutoselectFilterChecks.SphereRightFilter.Aspheric,
                        glassPackageType = manufactuerSetup.AutoselectFilterChecks.SphereRightFilter.glassPackageType,
                        GlassThickness = manufactuerSetup.AutoselectFilterChecks.SphereRightFilter.GlassThickness,
                        MaxValue = manufactuerSetup.AutoselectFilterChecks.SphereRightFilter.MaxValue,
                        MinValue = manufactuerSetup.AutoselectFilterChecks.SphereRightFilter.MinValue,
                    },

                    CylinderLeftFilter = new model.GlassThicknessMinMax
                    {
                        Aspheric = manufactuerSetup.AutoselectFilterChecks.CylinderLeftFilter.Aspheric,
                        glassPackageType = manufactuerSetup.AutoselectFilterChecks.CylinderLeftFilter.glassPackageType,
                        GlassThickness = manufactuerSetup.AutoselectFilterChecks.CylinderLeftFilter.GlassThickness,
                        MaxValue = manufactuerSetup.AutoselectFilterChecks.CylinderLeftFilter.MaxValue,
                        MinValue = manufactuerSetup.AutoselectFilterChecks.CylinderLeftFilter.MinValue,

                    },

                    CylinderRightFilter = new model.GlassThicknessMinMax
                    {
                        Aspheric = manufactuerSetup.AutoselectFilterChecks.CylinderRightFilter.Aspheric,
                        glassPackageType = manufactuerSetup.AutoselectFilterChecks.CylinderRightFilter.glassPackageType,
                        GlassThickness = manufactuerSetup.AutoselectFilterChecks.CylinderRightFilter.GlassThickness,
                        MaxValue = manufactuerSetup.AutoselectFilterChecks.CylinderRightFilter.MaxValue,
                        MinValue = manufactuerSetup.AutoselectFilterChecks.CylinderRightFilter.MinValue,
                    },

                    ColorTinge = manufactuerSetup.AutoselectFilterChecks.ColorTinge,
                    CommentsforWorkshop = manufactuerSetup.AutoselectFilterChecks.CommentsforWorkshop,
                    Multifocal = manufactuerSetup.AutoselectFilterChecks.Multifocal,
                    DigitalRelax = manufactuerSetup.AutoselectFilterChecks.DigitalRelax,
                    Enabled = manufactuerSetup.AutoselectFilterChecks.Enabled,
                    IgnoreLotusGlassThknsFltr = manufactuerSetup.AutoselectFilterChecks.IgnoreLotusGlassThknsFltr,
                    FrameTypeFilter = manufactuerSetup.AutoselectFilterChecks.FrameTypeFilter,
                    TingeTypeFilter = manufactuerSetup.AutoselectFilterChecks.TingeTypeFilter,
                },
                DecisionMapping = new model.DecisionMapping
                {
                    AllowedSalesChannels = manufactuerSetup.DecisionMapping.AllowedSalesChannels,
                    AllowedShippingAgents = manufactuerSetup.DecisionMapping.AllowedShippingAgents,
                    AllowSpecialInvReference = manufactuerSetup.DecisionMapping.AllowSpecialInvReference,
                    CheckLensStock = manufactuerSetup.DecisionMapping.CheckLensStock,
                    AllowedCountries = manufactuerSetup.DecisionMapping.AllowedCountries,
                    AllowedLensType = manufactuerSetup.DecisionMapping.AllowedLensType,
                    AllowFOVAutoUpgrade = manufactuerSetup.DecisionMapping.AllowFOVAutoUpgrade,
                    AllowLotusAutoUpgrade = manufactuerSetup.DecisionMapping.AllowLotusAutoUpgrade,
                    FrameAvailabilityAPIThreshold = manufactuerSetup.DecisionMapping.FrameAvailabilityAPIThreshold,
                    MaxNoOfItemsPerOrder = manufactuerSetup.DecisionMapping.MaxNoOfItemsPerOrder,
                    MaxOrderLimit = manufactuerSetup.DecisionMapping.MaxOrderLimit,
                    OrderLimitAPIThreshold = manufactuerSetup.DecisionMapping.OrderLimitAPIThreshold,
                    OrderLimitTimePeriod = manufactuerSetup.DecisionMapping.OrderLimitTimePeriod,
                },

                manGlassCodeMappings = manufactuerSetup.ManGlassCodeMapping.Select(s => new model.ManGlassCodeMapping {
                    GlassCode = s.GlassCode,
                    GlassOptionCode = s.GlassOptionCode,
                    Photo = s.Photo
                }).ToArray(),

                TimeStamp = DateTime.UtcNow,

                Id = new model.IdSetup
                {
                    id = manufactuerSetup.BaseData.Name,
                    Company = "default",
                },
               
                CreatedAt = DateTime.UtcNow,
                manGlassPackageMappings = manufactuerSetup.ManGlassPackageMapping.Select(s => new model.ManGlassPackageMapping
                {
                    SF6LensNameFilter = s.SF6LensNameFilter,
                    GlassCatalogueName = s.GlassCatalogueName,
                    Type = s.Type,
                }).ToArray(),

                MessageID = Guid.NewGuid().ToString(),
            };
        }
    }
}
