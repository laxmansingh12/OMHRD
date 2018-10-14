// <summary file = "BundleConfig.cs">
// Description : Class for Bundling Javascript files
// </summary>

namespace Praksys.UI.Administration
{
    #region Namespaces

    using System.Configuration;
    using System.Web.Optimization;

    #endregion Namespaces

    /// <summary>
    /// Class for Bundling Javascript files
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// For registering bundles
        /// </summary>
        /// <param name="bundles">BundleCollection</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();
            bundles.ResetAll();
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
            RegisterCSSBundle(bundles);
            RegisterKendoStyleBundle(bundles);
            RegisterJqueryStyleBundle(bundles);
            RegisterPraksysStyleBundle(bundles);
            RegisterJsLibraries(bundles);
            RegisterKendoandUtilityLibraries(bundles);
            RegisterCoreBundles(bundles);
            RegisterUnaBundle(bundles);
        }

        /// <summary>
        /// RegisterUnaBundle
        /// </summary>
        /// <param name="bundles">bundles</param>
        private static void RegisterUnaBundle(BundleCollection bundles)
        {
            var uaJS = new ScriptBundle("~/Areas/scripts/js").Include(
            "~/Areas/UnionsAgreements/scripts/route.js",
               "~/Scripts/services/RemoteService.js",
               "~/Areas/UnionsAgreements/Scripts/Service/Service.js",
               "~/Areas/UnionsAgreements/Scripts/Service/UACommonService.js",
               "~/Areas/UnionsAgreements/scripts/Controller/AgreementsController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/DetailsController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/FindYDelseController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/YdelseHistoryController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/AgreementsHistoryController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/DanReportController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/Aftaler.js",
               "~/Areas/UnionsAgreements/scripts/Controller/AuthController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/AftalerDetailsController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/NogletalController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/EksporterController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsMedicinController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsAlmenlaegegerningController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/KiropraktiskSatserController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsFodteapauterController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsFysioteapauterController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsPsykologhjaelpController.js",
               "~/Areas/UnionsAgreements/scripts/Controller/SatsSpecialisthelpController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/YGController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/GYpopupController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/OpretKladdePopUpController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/YdelseOfficielGrupperingController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/SatsTandlaegerController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/SatsTandplejereController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/TilfojFjernSpecialePopUpController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/IndlaesydelserController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/ReferencerController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/RefereresFraController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/GruppeOperationsController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/SendTilGodkendelseController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/EndreNavnController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/ViewPraeparaterController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/UdgavePopUpController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/NotesController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/ReguleringsprocentController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/ReguleringsmetoderController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/KopierYdelserPopupController.js",
                 "~/Areas/UnionsAgreements/scripts/Controller/YdelseNummerPopupControler.js",
                "~/Areas/UnionsAgreements/scripts/Controller/AftaleVariablePopUpController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/EndringdslogrController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/OrderMapServicesController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/TakstmappeReportsPopup.js",
                "~/Areas/UnionsAgreements/scripts/Controller/FindPreparator.js",
                "~/Areas/UnionsAgreements/scripts/Controller/ErstatFormelPopUpController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/MyndighedPopupController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/EarEyePopUpController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/RegulationReportlPopUpController.js",
                "~/Areas/UnionsAgreements/scripts/Controller/SkulYdelseController.js",
                "~/Areas/UnionsAgreements/Scripts/Service/UACommonService.js",
                "~/Areas/Provider/scripts/BusinessValidations/ProviderBusinessRulesService.js",
              "~/Areas/Provider/scripts/BusinessValidations/RelationBusinessRulesService.js",
              "~/Areas/Provider/scripts/BusinessValidations/BusinessRulesDataService.js",
              "~/Areas/Provider/scripts/directives/providerConfig.js",
              "~/Areas/Provider/scripts/directives/commonUI.js",
              "~/Areas/Provider/scripts/helpers/GridHelper.js",
              "~/Areas/Provider/scripts/services/AuditService.js",
              "~/Areas/Provider/scripts/services/cacheService.js",
              "~/Areas/Provider/scripts/services/DateService.js",
              "~/Areas/Provider/scripts/services/CommonYderFactory.js",
              "~/Areas/Provider/scripts/services/FunktionerService.js",
              "~/Areas/Provider/scripts/services/InfotypeService.js",
              "~/Areas/Provider/scripts/services/LegevalgRegelService.js",
              "~/Areas/Provider/scripts/services/MasterService.js",
              "~/Areas/Provider/scripts/services/ProviderCommonLib.js",
              "~/Areas/Provider/scripts/services/ProviderCommonServices.js",
              "~/Areas/Provider/scripts/services/SagsrelevanteOplysningerService.js",
              "~/Areas/Provider/scripts/services/DocumentService.js",
              "~/Areas/Provider/scripts/services/ProviderService.js",
               "~/Areas/Provider/scripts/services/SimpelKlassService.js",
               "~/Areas/Provider/scripts/services/YderHojestegrenserService.js",
               "~/Areas/Provider/scripts/services/RelationService.js",
               "~/Areas/Provider/scripts/services/DirtyFlagConfiguration.js",
               "~/Areas/Provider/scripts/services/FormatService.js",
               "~/Areas/Provider/scripts/services/CaseService.js",
               "~/Areas/Provider/scripts/services/TaskPopUpService.js",
               "~/Areas/Provider/scripts/services/ProviderAuthorityService.js",
               "~/Areas/Provider/scripts/services/ProviderClosureDataService.js",
               "~/Areas/Provider/scripts/services/ProviderEnumerator.js",
                 "~/Areas/Provider/scripts/services/PREnumerator.js",
               "~/Areas/Provider/scripts/services/ProviderHelper.js",
               "~/Areas/Provider/scripts/services/postnrfactory.js",
               "~/Areas/Provider/scripts/Controllers/route.js",
               "~/Areas/Provider/scripts/Controllers/YderController.js",
               "~/Areas/Provider/scripts/Controllers/EventSearchController.js",
               "~/Areas/Provider/scripts/Controllers/YderPersonController.js",
               "~/Areas/Provider/scripts/Controllers/LokationController.js",
               "~/Areas/Provider/scripts/Controllers/SearchYderController.js",
               "~/Areas/Provider/scripts/Controllers/FallesskabController.js",
               "~/Areas/Provider/scripts/Controllers/KlassifikationerController.js",
               "~/Areas/Provider/scripts/Controllers/VikarController.js",
               "~/Areas/Provider/scripts/Controllers/YderMapController.js",
               "~/Areas/Provider/scripts/Controllers/SearchYderMapController.js",
               "~/Areas/Provider/scripts/Controllers/InfotypeController.js",
               "~/Areas/Provider/scripts/Controllers/LegevalgRegelController.js",
               "~/Areas/Provider/scripts/Controllers/YderCockpitController.js",
               "~/Areas/Provider/scripts/Controllers/YderHistorikController.js",
               "~/Areas/Provider/scripts/Controllers/SearchFaellesskabController.js",
               "~/Areas/Provider/scripts/Controllers/SagsoplysningerController.js",
               "~/Areas/Provider/scripts/Controllers/SikredeController.js",
               "~/Areas/Provider/scripts/Controllers/YderHojestegrenserController.js",
               "~/Areas/Provider/scripts/Controllers/ReguleringerController.js",
               "~/Areas/Provider/scripts/Controllers/OpreteYderWindowController.js",
               "~/Areas/Provider/scripts/Controllers/OpreteFallesskabWindowController.js",
               "~/Areas/Provider/scripts/Controllers/GyldigfraWindowController.js",
               "~/Areas/Provider/scripts/Controllers/YderPersonGridController.js",
               "~/Areas/Provider/scripts/Controllers/OvrigeYderController.js",
               "~/Areas/Provider/scripts/Controllers/FunktionerController.js",
               "~/Areas/Provider/scripts/Controllers/OfficielleGraenseController.js",
               "~/Areas/Provider/scripts/Controllers/LokationerGridController.js",
               "~/Areas/Provider/scripts/Controllers/CockpitAfregningController.js",
               "~/Areas/Provider/scripts/Controllers/YderAdministrationCaseController.js",
               "~/Areas/Provider/scripts/Controllers/ChangeLogFormController.js",
               "~/Areas/Provider/scripts/Controllers/TaskPopUpController.js",
               "~/Areas/Provider/scripts/Controllers/ProviderClosurePopUpController.js",
               "~/Areas/Provider/scripts/Controllers/SagsrelevanteOplysningerController.js",
               "~/Areas/Provider/scripts/Controllers/AfsultSagController.js",
               "~/Areas/LocalAgreements/scripts/route.js",
                 "~/Areas/LocalAgreements/scripts/services/LokalAgreementsService.js",
                "~/Areas/LocalAgreements/scripts/controllers/CreateLokalAgreementController.js",
                 "~/Areas/LocalAgreements/scripts/controllers/FindAgreementController.js",
                 "~/Areas/LocalAgreements/scripts/controllers/YderModalController.js",
                 "~/Areas/LocalAgreements/scripts/controllers/RegningerModalController.js",
                 "~/Areas/LocalAgreements/scripts/services/LocalAgreementCommonService.js",
                 "~/Areas/LocalAgreements/scripts/Enumerators/LocalAgreementEnumerators.js",
                 "~/Areas/RuleEngine/scripts/route.js",
                 "~/Areas/RuleEngine/scripts/Service/RulesService.js",
                 "~/Areas/RuleEngine/scripts/Service/RulesCommonService.js",
                 "~/Areas/RuleEngine/scripts/Controller/IndexController.js",
                 "~/Areas/RuleEngine/scripts/Controller/RegelOverview.js",
                 "~/Areas/RuleEngine/scripts/Controller/CreateRegelAftale.js",
   "~/Areas/RuleEngine/scripts/Controller/DeleteRegelAftale.js",
   "~/Areas/RuleEngine/scripts/Controller/Regningsvalidering.js",
   "~/Areas/RuleEngine/scripts/Controller/RegelAfvistPopUpController.js",
   "~/Areas/RuleEngine/scripts/Controller/RegelConditions.js",
                    "~/Areas/RuleEngine/scripts/Controller/TilfojRegel.js",
                    "~/Areas/RuleEngine/scripts/Controller/RegelFamilyOverview.js",
                    "~/Areas/RuleEngine/scripts/Controller/RegelOpretKlade.js",
                    "~/Areas/RuleEngine/scripts/Controller/RegelHistory.js",
                    "~/Areas/RuleEngine/scripts/Controller/RegelSendTilGodkendelse.js",
                    "~/Areas/RuleEngine/scripts/Controller/CreateSpecificRegel.js",
                    "~/Areas/RuleEngine/scripts/Controller/FindRegelController.js",
                    "~/Areas/RuleEngine/scripts/Controller/DanEndringsRaportController.js",
                    "~/Areas/RuleEngine/scripts/Controller/RegelUdgavePopUpController.js",
            "~/Areas/RuleEngine/scripts/Controller/RegelEndreNavnController.js",
             "~/Areas/RuleEngine/scripts/Controller/RegelConditionPopUp.js",
            "~/Areas/RuleEngine/scripts/Controller/ManageRegelfamilie.js",
            "~/Areas/RuleEngine/scripts/Controller/SimulateRulesController.js",
              "~/Areas/Claims/scripts/route.js",
                "~/Areas/Claims/scripts/Controllers/DemoController.js",
                "~/Areas/Claims/scripts/Controllers/RegningerController.js",
                "~/Areas/Claims/scripts/Controllers/RegningerDetailsController.js",
                "~/Areas/Claims/scripts/Controllers/RegningstildelingController.js",
                "~/Areas/Claims/scripts/Services/Service.js",
                "~/Areas/Claims/scripts/Services/ClaimCommonService.js",
                "~/Areas/Claims/scripts/Controllers/HenvisningerController.js",
                "~/Areas/Claims/scripts/Controllers/BundterController.js",
                "~/Areas/Claims/scripts/Controllers/BundtDetailsController.js",
                "~/Areas/Claims/scripts/Controllers/RegningsoversigtController.js",
                "~/Areas/Claims/scripts/Enumerators/ClaimsEnumerators.js",
                "~/Areas/Claims/scripts/Controllers/EndringRegningerController.js",
                 "~/Areas/Claims/scripts/Controllers/BegrundelseTilYderPopUpController.js",
                "~/Areas/Claims/scripts/Controllers/BundtCommentController.js",
                "~/Areas/Claims/scripts/Controllers/HenvisningerDetailsController.js",
                "~/Areas/Claims/scripts/Controllers/ReguleringerController.js",
                "~/Areas/Claims/scripts/Controllers/IndberetviafilGridController.js",
                "~/Areas/Claims/scripts/Controllers/IndberetfilReguleringerController.js",
                "~/Areas/Claims/scripts/Controllers/OpdateringJusteringerUdbyderController.js",
                "~/Areas/Claims/scripts/Controllers/OpretteJusteringerUdbydergruppeController.js",
                "~/Areas/Claims/scripts/Controllers/OpretteJusteringerUdbyderController.js",
                "~/Areas/Claims/scripts/Controllers/UdbetalingsgrundlagController.js",
                "~/Areas/Claims/scripts/Controllers/LokalAftaleModalController.js",
                "~/Areas/Claims/scripts/Controllers/UdbetalingsgrundlagDetailController.js",
                "~/Areas/Claims/scripts/Controllers/AdjustPensionModalController.js",
                "~/Areas/Claims/scripts/Controllers/UdbetalingsgrundlagParkModalController.js",
                "~/Areas/Claims/scripts/Controllers/UdbetalingsgrundlagAttestModalController.js",
                "~/Areas/Claims/scripts/Controllers/ClearingRegningerDetailsController.js",
                 "~/Areas/Claims/scripts/Controllers/OrdinationDetailsController.js",
                  "~/Areas/Claims/scripts/Controllers/MoveBundlePopUpController.js",
                   "~/Areas/Claims/scripts/Controllers/FrigivBundterPopUpController.js",
                  "~/Areas/Claims/scripts/Controllers/SelectReguleringPopUpController.js",
                   "~/Areas/Claims/scripts/Services/ClaimCommonService.js",
                     "~/Areas/Payment/scripts/route.js",
                "~/Areas/Payment/scripts/Controllers/KontoPlanDetailsController.js",
                "~/Areas/Payment/scripts/Services/Service.js",
                 "~/Areas/Payment/scripts/Services/PaymentCommonService.js",
                   "~/Areas/Payment/scripts/Services/PaymentService.js",
                 "~/Areas/Payment/scripts/Controllers/KontospecifikationController.js",
                "~/Areas/Payment/scripts/Controllers/KontoPlannerOverviewController.js",
                "~/Areas/Payment/scripts/Controllers/PaymentDanReportController.js",
                "~/Areas/Payment/scripts/Controllers/PaymentUdgavePopUpController.js",
                 "~/Areas/Payment/scripts/Controllers/NemkontoStubController.js",
                "~/Areas/Payment/scripts/Controllers/ManageKontogrupperController.js",
                  "~/Areas/Payment/scripts/Controllers/OpretKladdeKontoplanerController.js",
                  "~/Areas/Payment/scripts/Controllers/KontoEndreNavnController.js",
                   "~/Areas/Payment/scripts/Controllers/SendTilGodkendelseKontoplanerController.js",
                  "~/Areas/Payment/scripts/Controllers/UdbetalingsgrundlagsearchController.js",
                   "~/Areas/Payment/scripts/Controllers/OrderPaymentController.js",
                  "~/Areas/Payment/scripts/Controllers/FindKontospecikationerController.js",
                  "~/Areas/Payment/scripts/Controllers/AttestereingSagsController.js",
                  "~/Areas/Payment/scripts/Controllers/UdbetalingerController.js",
                  "~/Areas/Payment/scripts/Controllers/BetalingOrdredetaljerController.js",
                  "~/Areas/Payment/scripts/Controllers/AfvistPopupInfromationController.js",
                  "~/Areas/Payment/scripts/Controllers/BetalingOrderMotordetaljerController.js",
                  "~/Areas/Payment/scripts/Controllers/BetalingMotorFejlPopupController.js",
                   "~/Areas/Payment/scripts/Enumerators/PaymentEnumerators.js",
                     "~/Areas/Payment/scripts/Controllers/OpretKontoplanPopupController.js",
                   "~/Areas/Payment/scripts/Controllers/NemkontoStatusDetailsPopupController.js",
                   "~/Areas/Payment/scripts/Controllers/KontonummerController.js",
                   "~/Areas/Payment/scripts/Controllers/KontonummerPopupController.js",
                    "~/Areas/Citizen/scripts/route.js",
             "~/Areas/Citizen/scripts/Services/Service.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenSearchController.js",
             "~/Areas/Citizen/scripts/Enumerators/CitizenEnumerators.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenDetailsController.js",
             "~/Areas/Citizen/scripts/Controllers/AddressDetailListingController.js",
             "~/Areas/Citizen/scripts/Controllers/RettighederController.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenCockpitController.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenCockpit1Controller.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenRelationAccordionController.js",
             "~/Areas/Citizen/scripts/Controllers/ChangeDoctorController.js",
             "~/Areas/Citizen/scripts/Controllers/OrderHealthCardController.js",
             "~/Areas/Citizen/scripts/Controllers/CitizenCardDetailsAccordionController.js",
            "~/Areas/Citizen/scripts/Controllers/PersonaligController.js",
            "~/Areas/Citizen/scripts/Controllers/GeografiskController.js",
            "~/Areas/Citizen/scripts/Controllers/ChangeLivingStatusController.js",
            "~/Areas/Citizen/scripts/Controllers/CitizenSikretGPGruppeHistoryController.js",
            "~/Areas/Citizen/scripts/Controllers/ForsikringInformationController.js",
            "~/Areas/Citizen/scripts/Controllers/CitizenStamdataController.js",
            "~/Areas/Citizen/scripts/Controllers/TransferJournalPopupController.js");
            //// Bundling but not minifying in debug mode
#if DEBUG
            uaJS.Transforms.Clear();
#endif

            bundles.Add(uaJS);
        }

        /// <summary>
        /// RegisterCoreBundles
        /// </summary>
        /// <param name="bundles">bundles</param>
        private static void RegisterCoreBundles(BundleCollection bundles)
        {
            var appJS = new ScriptBundle("~/Scripts/js");
            IncludeCoreJs_1(appJS);
            IncludeCoreJs_2(appJS);
            IncludeCoreJs_3(appJS);
            IncludeCoreJs_4(appJS);
            IncludeCoreJs_5(appJS);
            IncludeCoreJs_6(appJS);
            //// Bundling but not minifying in debug mode
#if DEBUG
            appJS.Transforms.Clear();
#endif
            bundles.Add(appJS);
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appjs">appjs</param>
        private static void IncludeCoreJs_1(Bundle appjs)
        {
            appjs.Include("~/scripts/app/App.js",
                "~/Scripts/angular/toaster.js",
                 "~/scripts/app/localize.js",
                "~/scripts/app/route.js",
                "~/scripts/Shared/Common/shortcutKeys-lib.js",
                "~/scripts/app/shortcutKeys.js",
                "~/scripts/app/spaGlobals.js",
              "~/scripts/app/ResourceDictionary.js",
              "~/Scripts/services/ExceptionHandler.js",
                 "~/Scripts/angular/toaster.js",
                 "~/scripts/controllers/LocaleController.js",
                "~/scripts/services/AuditLogService.js",
                "~/scripts/controllers/tabController.js",
                "~/scripts/controllers/HeaderController.js",
                "~/scripts/controllers/FooterController.js",
                "~/scripts/controllers/MenuController.js",
                 "~/scripts/controllers/AddressGenericController.js",
                  "~/Scripts/services/ValidationService.js",
                 "~/scripts/controllers/ConfirmationController.js",
                 "~/scripts/services/Praksys.UserInfo.js",
                 "~/scripts/services/HotLinkAccessService.js",
                  "~/scripts/services/Praksys.UI.GridExporter.js",
                  "~/scripts/controllers/RabbitMQFejledeBeskederController.js");
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appjs">appjs</param>
        private static void IncludeCoreJs_2(Bundle appjs)
        {
            appjs.Include("~/scripts/controllers/AssignResponsibilityToTeamController.js",
                "~/scripts/controllers/SagsoplysningerController.js",
              "~/scripts/controllers/SagLedelseController.js",

              "~/scripts/controllers/TeamController.js",

              "~/scripts/controllers/BrugerController.js",
              "~/scripts/services/EarchiveModelService.js",
              "~/scripts/controllers/EarchivePageController.js",
               "~/scripts/controllers/EarchiveDetailController.js",
              "~/scripts/controllers/EarchivePopupController.js",

              "~/scripts/controllers/ManualOpgaverController.js",
               "~/scripts/controllers/SagerController.js",
               "~/scripts/controllers/HendelseListController.js");
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appJs">appjs</param>
        private static void IncludeCoreJs_3(Bundle appJs)
        {
            appJs.Include("~/scripts/controllers/DemoController.js",
            "~/scripts/controllers/NoteController.js",
            "~/scripts/controllers/NotePopUpController.js",
           "~/scripts/controllers/MyndighedSansvarController.js",
            "~/scripts/controllers/HelpEditorController.js",
            "~/scripts/controllers/StatistikController.js",
                       "~/scripts/controllers/CombineResponsibilityController.js",
              "~/scripts/Shared/Common/cacheFactory.js",
               "~/scripts/services/sessionInjector.js",
           "~/scripts/Shared/contextService.js",
                     "~/scripts/services/CommonNotesService.js",
                   "~/scripts/services/REEnumerator.js",
                   "~/scripts/services/LAEnumerator.js",
                   "~/scripts/services/UAEnumerator.js",
                   "~/scripts/services/DirtyFlagService.js",
           "~/scripts/services/Praksys.UI.Validation.js",
                   "~/scripts/services/Praksys.Authorize.js",
                    "~/scripts/Shared/Common/Praksys.UI.Inactive.js",
                   "~/scripts/services/Praksys.UI.CommonUtility.js",
           "~/scripts/services/Praksys.UI.Message.js",
           "~/scripts/services/CommonEnumerator.js");
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appJs">appJs</param>
        private static void IncludeCoreJs_4(Bundle appJs)
        {
            appJs.Include(
                "~/scripts/services/EnumeratorCommon.js",
                "~/scripts/services/REEnumerator.js",
                 "~/scripts/services/DocumentViewerService.js",
                "~/scripts/services/PraksysCommonService.js",
                "~/scripts/services/AuthorityService.js",
                 "~/scripts/services/SagService.js",
                  "~/scripts/services/YderCockpitService.js",
                   "~/scripts/services/EarchiveService.js",
                    "~/scripts/services/AddressService.js",
                   "~/scripts/services/KendoValidation.js",
                    "~/scripts/Editor/pako_deflate.min.js",
                   "~/scripts/Google/geoxml3.js",
                      "~/scripts/Google/Praksys.Map.Plotter.js",
                      "~/scripts/Google/Praksys.Map.GeoCoder.js",
                       "~/scripts/controllers/DocumentDistributionController.js",
                 "~/scripts/controllers/RetighedController.js",
                 "~/scripts/controllers/AssignOpgaveToRolleController.js",
                 "~/scripts/controllers/SystemConfigurationController.js",
                 "~/scripts/controllers/UploadConfigController.js");
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appJs">appjs</param>
        private static void IncludeCoreJs_5(Bundle appJs)
        {
            appJs.Include("~/scripts/Shared/Common/Praksys.UI.Logger.js",
               "~/scripts/controllers/DocumentViewerController.js",
              "~/scripts/services/DictionaryService.js",
              "~/scripts/controllers/AuthorityAdminController.js",
               "~/scripts/controllers/RolleSansvarController.js",
               "~/scripts/controllers/UploadUserController.js",
                "~/scripts/controllers/TeamBrugerController.js",
                 "~/scripts/controllers/UpdatePasswordController.js",
              "~/scripts/controllers/TemplateController.js",
              "~/scripts/controllers/MessageController.js",
             "~/scripts/controllers/RolleController.js",
              "~/scripts/controllers/AssignTeamToBrugerController.js",
              "~/scripts/controllers/SagsrelevanteOplysningerController.js",
              "~/scripts/directives/pkview.js",
              "~/scripts/directives/Spinner.js",
              "~/scripts/directives/numericField.js",
              "~/scripts/directives/kendotooltip.js",
               "~/scripts/Shared/draggable.js",
               "~/scripts/directives/pksysTruncateLabel.js",
               "~/scripts/directives/SetZeroValueDirective.js",
             "~/scripts/directives/Hangfire.js",
             "~/scripts/directives/moveNext.js",
              "~/scripts/directives/addRow.js",
              "~/scripts/directives/moveNextGrid.js",
              "~/scripts/directives/noDirty.js");
        }

        /// <summary>
        /// IncludeCoreJs_1
        /// </summary>
        /// <param name="appjs">appjs</param>
        private static void IncludeCoreJs_6(Bundle appjs)
        {
            appjs.Include(
                 "~/scripts/Shared/ValidateOnHover.js",
                   "~/scripts/directives/CheckBoxList.js",
                "~/scripts/Shared/SetFocus.js",
                        "~/scripts/Shared/loader.js",
                        "~/scripts/Shared/ngEnter.js",
                         "~/scripts/directives/dynamicfield.js",
                          "~/scripts/Shared/focusOnSelStart.js",
                          "~/scripts/directives/ydelseNummer.js",
                          "~/scripts/JSLinq/linq-vsdoc.js",
                          "~/scripts/JSLinq/linq.js",
                "~/scripts/JSLinq/linq.min.js",
                "~/scripts/controllers/OrderReValidationController.js",
                 "~/scripts/services/InputFormatService.js",
                   "~/scripts/services/LAEnumerator.js",
                    "~/scripts/services/UAEnumerator.js",
                    "~/scripts/controllers/CoveringAreaMyndighedController.js",
                    "~/scripts/controllers/DekningsomradeController.js",
                    "~/scripts/Shared/ContextMenuHide.js",
                     "~/scripts/cognos/CognosLauncher.js",
                      "~/scripts/controllers/SogPaSagController.js",
                      "~/scripts/controllers/TransferSagToUserController.js",
                      "~/scripts/Shared/HangfireStatusPollingFactory.js",
                      "~/scripts/controllers/TeamAddressController.js",
          "~/Scripts/services/CoreHelpers.js",
            "~/Scripts/services/Notification.js",
                      "~/Scripts/services/CoreService.js",
              "~/Scripts/services/CoreUI.js",
              "~/Scripts/services/PageHelpers.js",
              "~/scripts/controllers/BeskederController.js");
        }

        /// <summary>
        /// Register kendo and moment Numeral
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterKendoandUtilityLibraries(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/kendo/js").Include(
                "~/Scripts/kendo/kendo.all.min.js",
                 "~/Scripts/kendo/Kendo-locale_da-DK.js",
                "~/Scripts/kendo/angular-kendo.js"));

            bundles.Add(new ScriptBundle("~/Scripts/moment/js").Include(
                "~/Scripts/moment/moment.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/numeral/js").Include(
                 "~/Scripts/numeral/numeral.min.js",
                    "~/Scripts/numeral/languages.min.js"));
        }

        /// <summary>
        /// Register js libraries
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterJsLibraries(BundleCollection bundles)
        {
            //// Bundling JS
            bundles.Add(new ScriptBundle("~/Scripts/jquery/js").Include(
                "~/Scripts/jquery/jquery-2.1.0.js"));
            bundles.Add(new ScriptBundle("~/Scripts/jqueryui/js").Include(
              "~/Scripts/jqueryui/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap/js").Include(
                "~/scripts/bootstrap/bootstrap.min.js",
                "~/scripts/bootstrap/bootstrap-notify.js"));

            bundles.Add(new ScriptBundle("~/Scripts/angular/js").Include(

                "~/Scripts/angular/angular.min.js",
                 "~/Scripts/angular/angular-animate.min.js",
                 "~/Scripts/angular/angular-sanitize.js",
                "~/Scripts/angular/angular-resource.min.js",
                "~/Scripts/angular/angular-ui-router.js",
                "~/Scripts/angular/underscore.js",
                "~/Scripts/angular/ui-bootstrap-tpls-0.10.0.js"));
        }

        /// <summary>
        /// Register praksys style sheets
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterPraksysStyleBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/styles").Include(
                "~/css/bootstrap-override.css",
                "~/css/kendo-override.css",
                "~/css/main.css",
                "~/css/header.css",
                "~/css/Claims.css",
                "~/css/Payment.css",
                "~/css/UnionAgreement.css",
                "~/css/Citizen.css",
                 "~/css/provider.css",
                  "~/css/animate.css"));

            bundles.Add(new StyleBundle("~/css/Corestyles").Include(
                "~/css/UnionAgreement.css"));
        }

        /// <summary>
        /// RegisterJqueryStyleBundle
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterJqueryStyleBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/jquery/styles").Include(
                "~/css/jquery/jquery-ui.css"));
        }

        /// <summary>
        /// RegisterKendoStyleBundle
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterKendoStyleBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/kendo/styles").Include(
                "~/css/kendo/kendo.common.min.css",
                "~/css/kendo/kendo.default.min.css",
                "~/css/kendo/kendo.dataviz.min.css",
                "~/css/kendo/kendo.dataviz.default.min.css"));
        }

        /// <summary>
        /// RegisterCSSBundle
        /// </summary>
        /// <param name="bundles">bundle object</param>
        private static void RegisterCSSBundle(BundleCollection bundles)
        {
            //// Bundling CSS
            bundles.Add(new StyleBundle("~/css/bootstrap/styles").Include(
                "~/css/bootstrap/bootstrap.css",
                "~/css/bootstrap/toaster.css",
                "~/css/bootstrap/bootstrap-theme.min.css",
                "~/css/bootstrap/font-awesome.min.css"));
        }
    }
}