using model = Model.Data.Models.Setups;

namespace Domain.Mapping.Dto.SetupDto
{
    public static class SetupToModel
    {
        public static model.SetupData ToModel(this SetupData data)
        {
            return new model.SetupData
            {
                id = "default",
                Company = "default_company",
                MessageID = data.MessageID,
                TimeStamp = data.TimeStamp,
                Source = data.Source,
                
                BaseData = new model.BaseData
                {
                    OutsourcedProductionEnabled = data.BaseData.OutsourcedProductionEnabled,
                    AutoGlassSelectionActivated = data.BaseData.AutoGlassSelectionActivated,
                    SkipOrdershavingWrshCmt = data.BaseData.SkipOrdershavingWrshCmt,
                    FirstChoiceARCode = data.BaseData.FirstChoiceARCode,
                    SecondChoiceARCode = data.BaseData.SecondChoiceARCode,
                },

                GlassThicknessMinMax = data.GlassThicknessMinMax?.Select(s => new model.GlassThicknessMinMax
                {
                    glassPackageType = s.glassPackageType,
                    GlassThickness = s.GlassThickness,
                    Aspheric = s.Aspheric,
                    MaxValue = s.MaxValue,
                    MinValue = s.MinValue,
                }).ToList(),

                EventTypeMappings = data.EventTypeMappings.Select(s => new model.EventTypeMapping 
                { 
                    EventType = s.EventType,
                    FunctionName = s.FunctionName,
                    MaxRetryAttempts = s.MaxRetryAttempts,
                    NextSteps = s.NextSteps.Select(s => new model.NextSteps
                    {
                        Topic = s.Topic,
                        Subject = s.Subject,
                        NextStepCondition = s.NextStepCondition,    
                        EventType = s.EventType,    
                    }).ToList(),
                    errorMappings = s.errorMappings?.Select(s => new model.ErrorMapping
                    {
                        ErrorType = s.ErrorType,
                        ActionType = s.ActionType,
                        EventType = s.EventType,
                        subject = s.subject,
                        Topic = s.Topic,    
                    }).ToList(),
                }).ToList(),

                GlassSelectionsParameters = new model.GlassParameters
                {
                    Disable = data.GlassSelectionsParameters.Disable,
                    Combinations = data.GlassSelectionsParameters.Combinations.Select(s => new model.Combinations
                    {
                        fieldofVision = s.fieldofVision,
                        AutoSelectionEnabled = s.AutoSelectionEnabled,
                        SingleVision = s.SingleVision,
                        Disabled = s.Disabled,
                        BlueFilter = s.BlueFilter,
                        Filter = s.Filter,
                        GlassGroupCode = s.GlassGroupCode,
                        GlassType = s.GlassType,
                        Gradient = s.Gradient,  
                        Mirrored = s.Mirrored,
                        MultiFocal = s.MultiFocal,
                        OfficeGlass = s.OfficeGlass,
                        ParameterNo = s.ParameterNo,
                        PhotoTropic = s.PhotoTropic,
                        Polarized = s.Polarized,
                        StandardTinge = s.StandardTinge,
                        Tinged = s.Tinged,

                        Priorities = s.Priorities?.Select(p => new model.Priorities
                        {
                            Manufacturers = p.Manufacturers.Select(m => new model.Manufacturers
                            {
                                SelectionCriteria = new model.SelectionCriteria
                                {
                                    LensOnStock = m.SelectionCriteria.LensOnStock,
                                    ExplicitCheck = m.SelectionCriteria.ExplicitCheck,
                                    LineOptionValidation = m.SelectionCriteria.LineOptionValidation,
                                    OrderVolume = m.SelectionCriteria.OrderVolume,
                                },

                                Restrictions = new model.Restrictions
                                {
                                    AllowedSalesChannel = m.Restrictions.AllowedSalesChannel,
                                    AllowedCountryCode = m.Restrictions.AllowedCountryCode,
                                    AllowedLensTypeOption = m.Restrictions.AllowedLensTypeOption,
                                    AllowedShippingAgent = m.Restrictions.AllowedShippingAgent,
                                    AllowSpecialInvReference = m.Restrictions.AllowSpecialInvReference,
                                    FrameAvailability = m.Restrictions.FrameAvailability,
                                    NoOfItemPerOrder = m.Restrictions.NoOfItemPerOrder,
                                }, 
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                }
            };      
            
        }
    }
}
