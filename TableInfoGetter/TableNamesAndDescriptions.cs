using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInfoGetter
{
    public class TableNamesAndDescriptions
    {
        private const string noInformationYet = "No information yet";
        private const string studyDataHeirarchy = "This is the Rave Study data heirarchy:<br/> DataPoint -> Record -> DataPage -> Instance -> Subject -> Site -> StudySite -> Study<br/><br/>";
        private const string migrationBoilerPlate = "Used when performing Migrations. See this article for more information: https://sites.google.com/a/mdsol.com/knowledgebase/home/departments/engineering/some-information-about-amendment-manager <br/>";


        #region A
        private const string ActionTypeR = "Enumeration of possible Action Types that roles can have. Usually used by joining with RoleActions to determine the actions a certain role can do in the system.";
        private const string Activations = "Lets you know which users have been activated.";
        private const string ActivationStatusR = "An enumeration of all the activation statuses for the user. (eg. RequiresActivation, Activated, etc.)";
        private const string AL9000StatusHash = "AL stands for architect loader, other than that I don't know.";
        private const string AL9000UploadTrail = "This tracks what has been loaded through Architect Loader. It contains the BLOB of the uploaded file in the \"UploadedFile\" column.";
        private const string AnalyteRanges = "Stores all the analyte ranges in Rave. Analyte ranges are used for Labs.";
        private const string Analytes = "Stored all the analytes in Rave. Used for Labs.";
        private const string ArchitectCopySources = "I think this is used for AmendmentManager.";
        private const string AuditCategoryR = "This is used for Audit categories. When you audit some data it uses the name of the audit here to determine the audit type. The audit type is then used in concert with AuditSubCategoryR to determine the audt text that appears.";
        private const string Audits = "Table containing all of the Audits in Rave. Audits are used to keep track in changes in the Rave system.";
        private const string AuditSubCategoryR = "Used with AuditCategoryR to determine the text and properties of an audit.";
        #endregion
        #region B
        private const string BulkStatusUpdateQueue = "Used for rollups. When rolling up data we place it on the queue to be rolled up. These are picked up by the app servers and processes them.";
        #endregion
        #region C
        private const string codingUsage = "Used for coding.";
        private const string crystalReportsUsage = "Used for Crystal Reports.";

        private const string CacheFlushNotification = "Records are added to this when we want to trigger a cache flush. Changes in this table are picked up by our sql notification code. Depending on the contents of the NotificationSource, we determine the cache we would like to flush.";
        private const string cDevices = "Used in custom functions. You can see the custom functions that we use this in \"Rave\\ravegarage\\Medidata.RBT.Features.Integration\\Features\\esig\\Downloads\\Download for esig_Misc\\Propagation_Project_VT1-P13_Draft_1.xml\" and \"Rave\\ravegarage\\Medidata.RBT.Features.Integration\\Features\\esig\\Downloads\\Downloads for eSig_Enhancements_Project\\Propagation_Project_Draft_1\".";
        private const string CentralLogging = "This is where we log information from Rave. This is being sunseted in favor of PaperTrail and Sumo (these are apps, not tables). If you don't see logs here, check those places.";
        private const string ChangeCodeRoles = "Links Change Codes to Roles. Change codes are added via the \"Other Settings\" link in \"Configuration\". When you add a change code there it will add that change code to that Role and only that role.";
        private const string ChangeCodes = "All the Change Codes in Rave. Change codes are added via the \"Other Settings\" link in \"Configuration\".";
        private const string CheckActions = "All the Check Actions in Rave. Check actions are the result of an edit check. The \"CheckSteps\" table contains the conditions to determine whether or not to trigger the check action. These two things together make up an \"Edit Check\".";
        private const string CheckLogTypeR = "Enumeration of the CheckLog types.";
        private const string Checks = "All the edit checks in rave. An edit check is made up of a series of check steps and check actions. This table provides an area to link those two things together under a common name and other common properties.";
        private const string CheckSteps = "All the Check Steps in Rave. Check steps are the preconditions to \"fire\" (activate) an edit check. The \"CheckActions\" table contains the results of the series of check steps evaluating to true. These two things together make up an \"Edit Check\".";
        private const string ClinicalSignificance = "Part of labs. When you mark a field as \"Prompt for Clinical Significance\" it will use this. How? I am not 100% sure, but I think that when one of the ClinicalSiginicance code is detected it will prompt on the datapoint that it is clinically signifigant.";
        private const string ClinicalSignificanceCodes = "Part of labs. When you mark a field as \"Prompt for Clinical Significance\" it will use this. How? I am not 100% sure, but I think that when one of the ClinicalSiginicance code is detected it will prompt on the datapoint that it is clinically signifigant.";
        private const string ClinicalViewClinSigStatusR = "Enumeration of possible clinical signature statuses.";
        private const string ClinicalViewColumnTypeR = "Enumeration of possible clinical view column types";
        private const string ClinicalViewStatusR = "Enumeration of possible clinical view statuses";
        private const string CLStatusHash = "The config loader status hash. The HashSerialization contains the actual contents of the Config Loader excel document that is uploaded. A similar process to the one described in this article (https://sites.google.com/a/mdsol.com/knowledgebase/home/departments/engineering/modifying-rave-config-loader-templates) may be useable to extract the actual files.";
        private const string CoderDictLevelComponents = "Used for coding. Each coding column has one to many coder dictionary level components.";
        private const string CoderLocale = "Used for coding. Many locales can be linked to a single coding dictionary. They are used so that we can have different codings for different values in different locales (jpn, eng).";
        private const string CodingColumns = "Used for coding. A coding dictioanry contains many coding columns which, in turn, contains many coding values.";
        private const string CodingDictionaries = "Used for coding. The highest level of the coding heirarchy. Coding dictionaries act like dictionaries in real life, taking a term in english and \"Coding\" it to a different term. For instance, if someone puts in \"migraine\" it may code it as \"headache - level 1\". Different dictionaries define different ways to \"code\" the same value.";
        private const string CodingEntries = "Used for coding. The lowest level of the coding heirarchy. Coding entries are the key/value paris of the dictionary. The \"Term\" column is the key in the dictionary, the \"Code\" column is the value. ";
        private const string CodingValues = "Used for coding. When you code a data point in old style coding, extra coding information comes with it. I believe that coder entries can be linked together so that if you have one, others go with it. Coder values coding entry and the other linked coding entries.";
        private const string ConfigLoaderColumns = "Enumeration of valid columns for configuration loader uploads.";
        private const string ConfigLoaderExcelFiles = "Configuration Loader excel files available for download as templates.";
        private const string ConfigLoaderLogs = "Logs of changes that have been done using the configuration loader.";
        private const string ConfigLoaderWorksheets = "Enumeration of valid worksheets for configuration loader uploads.";
        private const string Configuration = "Contains global configuration information for rave. <br/>Some useful information it contains:<br/>It contains Mauth authentication information<br/>The cache flush url that RWS uses to clear the cache.";
        private const string CopiedSubjects = "Subjects copied during amendment migration.";
        private const string CRFFiles = "Files uploaded through a form with a \"File\" field.";
        private const string CRFVersions = "All the CRF versions in Rave. When you make changes to a project you can publish a new \"CRF Version\" these allow you to go between old and new versions of projects. They are used when you want to migrate from an old to a new version. It is also visible on every page you can enter user information.";
        private const string CustomFunctions = "All the custom functions in Rave. Custom Functions are user created bits of code. These can be in C#, sql, or visual basic.";
        #endregion
        #region D
        private const string dataClarificationForm = "This pertains to functionality called \"DataClarificationForm\".";
        private const string doubleDataEntryBoilerplate = "This pertains to functionality called \"Double Data Entry (DDE)\".";

        private const string DataDictionaries = "All the DataDictionaries in Rave. Data dictionaries map an entered value to another type of data. You will see that reflected in the audit like this: \"User entered 'originalValue (dataDictionaryMappedValue)' \"";
        private const string DataDictionaryEntries = "All the DataDictionaryEntries in Rave. Data dictionaries entries are the key/value pairs that make up a data dictionary.";
        private const string DataPages = studyDataHeirarchy + "All the DataPages in Rave. A data page is an instance of a form.";
        private const string DataPointReviewStatus = "Contains all the DataPoints that require review and whether or not they have been reviewed yet and by which ReviewGroup.";
        private const string DataPoints = studyDataHeirarchy + "All the DataPoints in Rave. A data point is one point of user entered data entered in our Electronic Data Capture.";
        private const string DataPointsDDE = "Data points captured for data points that require Double Data Entry (DDE). Data points require at least two \"passes\" (entries of data), the first pass and the second pass. If the in architect the field was set as \"AutoReconciled\" then if those two are the same it will automatically accept the data as good if the two passes are identical. Otherwise, a separate user must put in the final \"correct\" value.";
        private const string DataPointUntranslated = "Data points can require translation if the field was set as requiring translation in Rave. This holds information about all data points which have yet to be translated.";
        private const string Derivations = "All the derivations in Rave. A derivation is when the data in one field is obtained from the data input into another field. It is setup in architect, in the draft, go to derivations in the left hand menu. It is very similar to an edit check. Consisting of steps to derive something (contained in the \"DerivationSteps\" table) and the thing that is actually derived from those steps (contained in the \"Derivations\" table).";
        private const string DerivationSteps = "All the derivations steps in Rave. A derivation is when the data in one field is obtained from the data input into another field. It is setup in architect, in the draft, go to derivations in the left hand menu. It is very similar to an edit check. Consisting of steps to derive something (contained in the \"DerivationSteps\" table) and the thing that is actually derived from those steps (contained in the \"Derivations\" table).";
        private const string DesignObjectTypeR = "Enumeration of all the design object types.";
        #endregion
        #region E
        private const string EmailAddressTypeR = "Enumeration of possible email types (To, CC, BCC).";
        private const string ExternalSystems = "The external systems that Rave may be hooked up to. For now it only supports iMedidata (ID 1).";
        #endregion
        #region F
        private const string FieldRestrictions = "Used in combination with RestrictionTypeR to determine view and entry restrictions. The field with the FieldID is locked for the role with the RoleID with the type of restriction specified by the RestrictionType.";
        private const string FieldReviewGroups = "Used by the requires manual review checkbox in architect. If you go to the field and select 3 review groups from the \"Require Manual Reviews\" section Rave makes 3 records, each with the same fieldID (the one of the field you edited) and 3 different ReviewGroupIDs (one matching each review group).";
        private const string Fields = "All the Fields in Rave. Fields are created on an architect Form and can be \"log\" (logged several times over the course of several visits) or \"standard\" logged once and never change. The actual data created in EDC on a field is called a record. One field may have several records if it is a \"log\" field. \"standard\" fields have only one record with a record position of \"0\".";
        private const string FolderForms = "Mapping from a folder to a form. One form can appear in many different folders. One folder can contain many different forms.";
        private const string Folders = "All the Folders in Rave. A folder is created in a study and contains forms. A folder is a way of organizing a group of forms. An \"Instance\" is the corresponding edc entry. When a folder is created for a subject is called an \"Instance\" (as it is an instance of the foder).";
        private const string FormRestrictions = "Used in combination with RestrictionTypeR to determine view and entry restrictions. The form with the FormID is locked for the role with the RoleID with the type of restriction specified by the RestrictionType.";
        private const string Forms = "All the Forms in Rave. A form is a grouping of fields. For instance, a form named \"Vitals\" may contain a field for \"Heart Rate\" and a field for \"Weight\"";
        #endregion
        #region H
        private const string HelpPages = "The pages the appear when you click a help icon in Rave.";
        #endregion
        #region I
        private const string Instances = "All the Instances in Rave. An \"Instance\" is the corresponding edc entry of a \"folder\". When a folder is created for a subject is called an \"Instance\" (as it is an instance of the foder).";
        private const string Interactions = "All the Interactions in Rave. This contains metadata about the interactions in Rave.";
        private const string InteractionStatusR = "Enumeration of all the interaction statuses.";
        #endregion
        #region J
        #endregion
        #region K
        #endregion
        #region L
        private const string Localizations = "The available locales (english, japanese, etc.)";
        private const string LocalizedDataStrings = "When a user enters a string for a form, study, pretty much any data into rave, it becomes a localized data string. It is localized into every locale in the Localizations table automatically. You can then use translation workbench to enter a specific value for a specific locale so that when you switch locales for the user on the \"My Profile\" page it will appear as the localized text. Environment names must be localized in the LocalizedDataStrings table or else Rave will not load.";
        private const string LocalizedStrings = "Standardized strings that are localized by Medidata before deployment.";
        private const string LockStatusR = "Enumeration of the possible lock statuses of a datapoint or datapage (Unlocked, Locked, Frozen). ";
        private const string LoginAttempts = "Each attempt to login to Rave, whether successful or not is logged in this table.";
        #endregion
        #region M
        private const string MarkingGroupCategoryR = "Enumeration of the type of markings to which the marking group can respond.";
        private const string MarkingGroups = "Group that can place and react to markings that are placed on DataPoints.";
        private const string Markings = "Queries, Stickies, Protocol Deviations, or Comments raised against data points. These are responded to by users in Marking Groups.";
        private const string MarkingTypeR = "Enumeration of the marking types that may be raised against at data point.";
        private const string Matrix = "A matrix is a grouping of folders in Architect.";
        private const string MissingCodes = "Code to describe why a datapoint was not entered.";
        private const string ModuleActions = "The actions that the module can perform on DataPoints.";
        private const string ModulePages = "The webpages that make up a module.";
        private const string ModulesR = "Enumeration of the modules in Rave. Used in combination with the UserObjectRole table to determine if a user with a certain role has permissions to access a certain module.";      
        #endregion
        #region N
        #endregion
        #region O
        private const string ObjectLocks = "Locking mechanism used by the integration service.";
        private const string ObjectStatusAllRoles = "Used for rollups. This table maintains the statuses (and therefore the status icons) or all the rave objects. The statuses \"roll up\" from the lowest object in the chain of ineritance (DataPoint is the lowest). And travels up the chain of inheritance, calculating the statuses all the way up the chain. This adobe connect video https://mdsol.adobeconnect.com/_a201375050/p1ahfulb21p/ is helpful in giving an overview of how rollups work. The \"BulkStatusUpdateQueue\" table is used to trigger rollups on app nodes.";
        private const string ObjectStatusR = "Enumeration of possible statuses that an object can have. This enumeration is a flag, so the various values can be logical (and)ed or (or)ed together.";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        
        #endregion
        #region P
        #endregion
        #region Q
        #endregion
        #region R

        private const string raveSafetyGatewayBoilerPlate = "RSG stands for Rave Saftey Gateway. This table is used by that module.<br/>";

        private const string RoleActions = "Keeps all actions for all roles. It is usually used by joining with the \"RolesAllModules\" table. The result of this join is usually combines with \"ActionTypeR\" to get the valid action types for a role.";
        private const string RolesAllModules = "Keeps a list of all the roles across all modules. The roleID from this table, combined with the \"RoleActions\" table defines what ActionTypes are valid from the role. The ActionTypes are fetched from the table \"ActionTypesR\". So a user with RoleID of \"2\" would join with \"RoleActions\" to see that it has ActionTypeIDs \"1, 2, 7\" which correspond to their english privileges in \"ActionTypeR\". Example action types are things like \"read\", \"freeze\", \"FirstPass\"";
        #endregion
        #region S
        #endregion
        #region T
        #endregion
        #region U
        private const string batchUploaderBoilerPlate = "Used for Batch Uploader. This table will only be in your system when you have the batch uploader module installed.<br/>";

        private const string UnitDictionaries = "All the UnitDictionaries in Rave.  Unit dictionaries map an entered value to the unit that measures it. For instance, if you wanted to say something is six centimeters you could set \"cm\" as a unit dictionary. It will appear to the right of the field in EDC.";
        private const string UnitDictionaryEntries = "All the UnitDictionaryEntries in Rave. Unit dictionaries entries are the key/value pairs that make up a unit dictionary.";
        private const string UploadCollectionProviderTypeR = "Enumeration of the upload collection provider types. This should match the CollectionProviderTypeID column in the UploadStudyThreads table.<br/><br/><div>Here is an example row:<br>ID&nbsp;&nbsp;&nbsp; UploadProjectConfigID&nbsp;&nbsp;&nbsp; UploadFileConfigID&nbsp;&nbsp;&nbsp; UploadDirectoryID&nbsp;&nbsp;&nbsp; StudyID&nbsp;&nbsp;&nbsp; UploadThreadID&nbsp;&nbsp;&nbsp; CollectionProviderTypeID<br>33&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp; 1924&nbsp;&nbsp;&nbsp; 18&nbsp;&nbsp;&nbsp; 1<br></div>";
        private const string UploadDirectories = "The directories where the files to upload in batch uploader sit. This should point to a real position on the user's machine. In that location should be files to upload. The ID of this row is used in the UploadStudyConfigs table as a foreign key.<br/><br/><div>Here is an example row:<br>UploadProjectConfigID&nbsp;&nbsp;&nbsp; UploadFileConfigID&nbsp;&nbsp;&nbsp; UploadDirectoryID&nbsp;&nbsp;&nbsp; Environment&nbsp;&nbsp;&nbsp; Created&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; EffectiveFrom&nbsp;&nbsp;&nbsp; Active<br>1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp; &lt;ALL&gt;&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 1<br></div>";
        private const string UploadFileConfigs = "Information about the type of files found in the upload directories. FileTypeID comes from the UploadFileTypeR table and represents the type of file (Delimited Text, XML, ExcelXML). IncOrFull comes from UploadIncrOrFullR. The ID of this row is used in the UploadStudyConfigs table as a foreign key.<br/><br/><div>Here is an example row:<br>UploadFileConfigID&nbsp;&nbsp;&nbsp; UploadFileConfigName&nbsp;&nbsp;&nbsp; FileTypeID&nbsp;&nbsp;&nbsp; IncrOrFull&nbsp;&nbsp;&nbsp; FileExtension&nbsp;&nbsp;&nbsp; Delimiter&nbsp;&nbsp;&nbsp; NoCase&nbsp;&nbsp;&nbsp; HasHeader&nbsp;&nbsp;&nbsp; CreateInstances&nbsp;&nbsp;&nbsp; CreateLogRecords&nbsp;&nbsp;&nbsp; CreateDataPages&nbsp;&nbsp;&nbsp; Matrix&nbsp;&nbsp;&nbsp; UseInstanceDates&nbsp;&nbsp;&nbsp; UseInstanceTimeWindows&nbsp;&nbsp;&nbsp; UseFolderOpenDays&nbsp;&nbsp;&nbsp; AddIfNotInMatrix&nbsp;&nbsp;&nbsp; InsertExtra&nbsp;&nbsp;&nbsp; ClearMissingFields&nbsp;&nbsp;&nbsp; LabID&nbsp;&nbsp;&nbsp; Created&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; EffectiveFrom&nbsp;&nbsp;&nbsp; Active&nbsp;&nbsp;&nbsp; MarkingDelimiter&nbsp;&nbsp;&nbsp; RunCleaningEngineInBatchMode&nbsp;&nbsp;&nbsp; UseStudySiteNumber&nbsp;&nbsp;&nbsp; IgnoreKeysForRecordReference<br>1&nbsp;&nbsp;&nbsp; fileConfigName&nbsp;&nbsp;&nbsp; 3&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; zip&nbsp;&nbsp;&nbsp; .&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; PRIMMAT&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; NULL&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; NULL&nbsp;&nbsp;&nbsp; 2014-05-06 21:23:20.107&nbsp;&nbsp;&nbsp; 2014-05-06 21:23:20.107&nbsp;&nbsp;&nbsp; 2014-05-06 21:23:20.107&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; NULL&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0<br></div>";
        private const string UploadFiles = "Keeps track of the files that have been uploaded via batch uploader.";
        private const string UploadFileTypeR = "Used as a foreign key in the UploadFileConfigs table. Describes the type of file being uploaded (Delimited Text, XML, ExcelXML).<br/><br/><div>Here is an example row:<br>FileTypeID&nbsp;&nbsp;&nbsp; FileType<br>1&nbsp;&nbsp;&nbsp; Delimited Text<br></div>";
        private const string UploadIncrOrFullR = "Used as a foreign key in the UploadFileConfigs table.<br/><br/><div>Here is an example row:<br>ID&nbsp;&nbsp;&nbsp; Name<br>0&nbsp;&nbsp;&nbsp; Incremental<br></div>";
        private const string UploadProjectConfigs = "Linked to the Rave Projects table and the Rave ChangeCodes table via foreign keys.<br/><br/><div>Here is an example row:<br>UploadProjectConfigID&nbsp;&nbsp;&nbsp; Source&nbsp;&nbsp;&nbsp; FileType&nbsp;&nbsp;&nbsp; CreateSubject&nbsp;&nbsp;&nbsp; MissingRecordsProcessing&nbsp;&nbsp;&nbsp; LockRecords&nbsp;&nbsp;&nbsp; Created&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; EffectiveFrom&nbsp;&nbsp;&nbsp; Active&nbsp;&nbsp;&nbsp; ProjectId&nbsp;&nbsp;&nbsp; ProjectName&nbsp;&nbsp;&nbsp; ChangeCode&nbsp;&nbsp;&nbsp; FileNamePartSeparator&nbsp;&nbsp;&nbsp; FileNameComposition&nbsp;&nbsp;&nbsp; QueryMarkingGroupID&nbsp;&nbsp;&nbsp; StickyMarkingGroupID&nbsp;&nbsp;&nbsp; QueryRequiresResponse&nbsp;&nbsp;&nbsp; QueryCloseOnChange&nbsp;&nbsp;&nbsp; RunInSeparateThread&nbsp;&nbsp;&nbsp; SubjectLoopSleep&nbsp;&nbsp;&nbsp; CollectionProviderTypeID&nbsp;&nbsp;&nbsp; Priority&nbsp;&nbsp;&nbsp; KeepLatestRaveChanges&nbsp;&nbsp;&nbsp; MaxRecords<br>1&nbsp;&nbsp;&nbsp; theSource&nbsp;&nbsp;&nbsp; zip&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 2014-05-06 20:46:55.970&nbsp;&nbsp;&nbsp; 2014-05-06 20:46:55.970&nbsp;&nbsp;&nbsp; 2014-05-06 20:46:55.970&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 1740&nbsp;&nbsp;&nbsp; 30562&nbsp;&nbsp;&nbsp; 2&nbsp;&nbsp;&nbsp; a&nbsp;&nbsp;&nbsp; NULL&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 10&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 999999<br><br></div>";
        private const string UploadServices = "Information about the batch uploader status running on the machine. Servicename should match the service name in the services panel in Windows. Status should match one of the values in UploadServiceStatusR.<br/><br/><div>Here is an example row:<br>UploadServiceID&nbsp;&nbsp;&nbsp; ServiceName&nbsp;&nbsp;&nbsp; RefreshInterval&nbsp;&nbsp;&nbsp; HostName&nbsp;&nbsp;&nbsp; TcpListenerPort&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; NoActivity&nbsp;&nbsp;&nbsp; Status&nbsp;&nbsp;&nbsp; CreateThreads<br>1&nbsp;&nbsp;&nbsp; Medidata Batch Loader 3.0.0.0 - 1&nbsp;&nbsp;&nbsp; 60&nbsp;&nbsp;&nbsp; DD7ZJ4CX1&nbsp;&nbsp;&nbsp; 5999&nbsp;&nbsp;&nbsp; 2014-05-08 15:53:34.760&nbsp;&nbsp;&nbsp; NULL&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 1<br></div>";
        private const string UploadServiceStatusR = "The status of the batch uploader upload service. Used as a foreign key in the UploadServices table.<br/><br/><div>Here is an example row:<br>ID&nbsp;&nbsp;&nbsp; Name<br>0&nbsp;&nbsp;&nbsp; Stopped<br></div>";
        private const string UploadStudyConfigs = "The is the configuration for what the study thread picks up. It shares many foreign key constraints with UploadStudyThreads. It is linked to the UploadProjectConfigs via the UploadProjectConfigID table for information about the project configuration. UploadFileConfigID has a foregin key constraint on UploadFileConfigs. It is linked to the UploadDirectories table for information about where the study sits. <br/><br/><div>Here is an example row:<br>UploadProjectConfigID&nbsp;&nbsp;&nbsp; UploadFileConfigID&nbsp;&nbsp;&nbsp; UploadDirectoryID&nbsp;&nbsp;&nbsp; Environment&nbsp;&nbsp;&nbsp; Created&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; EffectiveFrom&nbsp;&nbsp;&nbsp; Active<br>1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp; &lt;ALL&gt;&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 1<br></div>";
        private const string UploadStudyThreads = "The thread that picks up Studies for uploading. It is linked to the the UploadThreads table via the UploadThreadID for information about the thread itself. It is linked to the UploadProjectConfigs via the UploadProjectConfigID table for information about the project configuration. It is linked to the UploadDirectories table for information about where the study sits. It contains a studyID which matches a study in Rave in the Studies table. It contains an UploadThreadID which matches a record the UploadThreads table. It contains a UploadCollectionProviderTypeID which is linked to a record in UploadCollectionProviderTypeR. This record will be deleted by the stored produre \"spUploadThreadLoadByServiceID\" if it is incorrect.<br/><br/><div>Here is an example row:<br>UploadProjectConfigID&nbsp;&nbsp;&nbsp; UploadFileConfigID&nbsp;&nbsp;&nbsp; UploadDirectoryID&nbsp;&nbsp;&nbsp; Environment&nbsp;&nbsp;&nbsp; Created&nbsp;&nbsp;&nbsp; Updated&nbsp;&nbsp;&nbsp; EffectiveFrom&nbsp;&nbsp;&nbsp; Active<br>1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp; &lt;ALL&gt;&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 2014-05-06 21:29:46.707&nbsp;&nbsp;&nbsp; 1<br></div>";
        private const string UploadThreads = "The threads that can pick up files to upload. The ThreadName must be in the format \"Worker[1] number\". The word \"number\" should be replaced by a thread integer to identify the thread, meaning this is valid \"Worker[1] 1\". The upload serviceID tells you which service is handling the thread and has a foreign key constraint on the \"UploadServices\" table. CollectionProviderTypeID is a foreign key constraint against the \"UploadCollectionProviderTypeR\" table. This record will be deleted by the stored produre \"spUploadThreadLoadByServiceID\" if it is incorrect. <br/><br/><div>Here is an example row:<br>UploadThreadID&nbsp;&nbsp;&nbsp; ThreadName&nbsp;&nbsp;&nbsp; UploadServiceID&nbsp;&nbsp;&nbsp; CollectionProviderTypeID&nbsp;&nbsp;&nbsp; Items&nbsp;&nbsp;&nbsp; LastItemProcessedOn&nbsp;&nbsp;&nbsp; RefreshedOn<br>18&nbsp;&nbsp;&nbsp; Worker[1] 1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp; 0&nbsp;&nbsp;&nbsp; 2014-05-08 14:02:56.607&nbsp;&nbsp;&nbsp; 2014-05-08 16:01:40.113<br></div>";
        private const string UserAuditQueue = "Used when auditing.";
        private const string UserGroups = "A literal group of the users. The \"Users\" table has a column \"UserGroup\" which is linked to this table. A user group can have its own permissions that restrict what users in that group may do.";
        private const string UserModules = "Mapping from UserGroups (NOT USERS!) to the modules they may use. Modules are things like RaveSafteyGateway, EDC, Architect, etc.";
        private const string UserObjectRole = "Used to grant users (the GrantToObject) the role defined by RoleID over the GrantOnObject (Usually a study). So, user \"SomeUser\" has role \"SomeRole\" over GrantOnObject \"SomeStudy\"";
        private const string UserPermissionHistory = "Used when updating a user's permissions through User Administration.";
        private const string UserPermissionTypeR = "Enumeration of the user permission types.";
        private const string Users = "All the users in Rave. Users are created and administered through user administration. This is where certain users who log in to the system can have different privileges assigned to them through \"Roles\". Subjects are specific to a study, users are the people who log in to Rave.";
        private const string UserSettings = "Settings to personalize the Rave experience to each user, such as PageSize.";
        private const string UserStudySites = "Table to link Users to the StudySite they may access.";
        #endregion
        #region V
        #endregion
        #region W
        #endregion

        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";
        //private const string noInformationYet = "Noyet";

        public static Dictionary<string, string> tableNameToDescription = new Dictionary<string, string>
        {
            #region A
            {"ActionTypeR", ActionTypeR},
            {"Activations", Activations}, 
            {"ActivationStatusR", ActivationStatusR}, 
            {"AL9000_XSLTTransforms", noInformationYet}, 
            {"AL9000StatusHash", AL9000StatusHash }, 
            {"AL9000UploadTrail", AL9000UploadTrail }, 
            {"AllRestrictedStrings", noInformationYet}, 
            {"AnalyteRangeChanges", noInformationYet}, 
            {"AnalyteRanges", AnalyteRanges }, 
            {"Analytes", Analytes }, 
            {"ArchitectCopySources", ArchitectCopySources }, 
            {"ArchitectGroups", noInformationYet}, 
            {"AuditActionRestrictions", noInformationYet}, 
            {"AuditCategoryR", AuditCategoryR}, 
            {"Audits", Audits}, 
            {"AuditSubCategoryR", AuditSubCategoryR }, 
            #endregion
            #region B
            {"BK_20110201_01_DCS_Configuration", noInformationYet}, 
            {"BK_GPTCH_236_CheckOIDFix_NO_PURGE", noInformationYet}, 
            {"BK_GPTCH_236_DerivationOIDFix_NO_PURGE", noInformationYet}, 
            {"BK_GPTCH_237_OIDFix_NO_PURGE", noInformationYet}, 
            {"BK_WR_217660_WebServicesConfigurableDatasetConfiguration", noInformationYet}, 
            {"BK_WR_217660_WebServicesConfigurableDatasetFormats", noInformationYet}, 
            {"BK_WR_217660_WebServicesConfigurableDatasetObjects", noInformationYet}, 
            {"BK_WR_DT13946_LogMessages_NOPURGE", noInformationYet}, 
            {"BK_WR_DT14111_DeActivedUserAccounts_NO_PURGE", noInformationYet}, 
            {"BK_WR_DT14111_OldAndNewUserIDs_NO_PURGE", noInformationYet}, 
            {"BK_WR_MCC63497_CoderDecisions_NO_PURGE", noInformationYet}, 
            {"BK_WR_MCC63497_CoderValues_NO_PURGE", noInformationYet}, 
            {"BK_WR_MCC63497_Datapoints_NO_PURGE", noInformationYet}, 
            {"BK_WR_MCC75952_DeActivatedUserAccounts", noInformationYet}, 
            {"BK_WR_MCC75966_UserTable", noInformationYet}, 
            {"BulkStatusUpdateQueue", BulkStatusUpdateQueue},
            #endregion
            #region C
            {"CacheFlushNotification", CacheFlushNotification}, 
            {"CasTickets", noInformationYet}, 
            {"cDevices", cDevices}, 
            {"CentralLogging", CentralLogging}, 
            {"ChangeCodeRoles", ChangeCodeRoles}, 
            {"ChangeCodes", ChangeCodes}, 
            {"CheckActions", CheckActions}, 
            {"CheckLogs", noInformationYet}, 
            {"CheckLogTypeR", CheckLogTypeR}, 
            {"Checks", Checks}, 
            {"CheckSteps", CheckSteps}, 
            {"ClinicalSignificance", ClinicalSignificance}, 
            {"ClinicalSignificanceCodes", ClinicalSignificanceCodes}, 
            {"ClinicalViewClinSigStatusR", ClinicalViewClinSigStatusR}, 
            {"ClinicalViewColumns", noInformationYet}, 
            {"ClinicalViewColumnTypeR", ClinicalViewColumnTypeR}, 
            {"ClinicalViewControl", noInformationYet}, 
            {"ClinicalViewControlTracking", noInformationYet}, 
            {"ClinicalViewErrors", noInformationYet}, 
            {"ClinicalViewErrors2", noInformationYet}, 
            {"ClinicalViewProjectResults", noInformationYet}, 
            {"ClinicalViewProjects", noInformationYet}, 
            {"ClinicalViewRunModeR", noInformationYet}, 
            {"ClinicalViews", noInformationYet}, 
            {"ClinicalViewStatusR", ClinicalViewStatusR}, 
            {"ClinicalViewTemplateDefinitions", noInformationYet}, 
            {"CLStatusHash", CLStatusHash}, 
            {"CoderConfigurations", codingUsage}, 
            {"CoderDecisions", codingUsage}, 
            {"CoderDictLevelComponents", CoderDictLevelComponents}, 
            {"CoderFieldConfigurationWorkFlowData", codingUsage}, 
            {"CoderLinkedFieldConfigurations", codingUsage}, 
            {"CoderLocale", CoderLocale}, 
            {"CoderRequestDetailsOld", noInformationYet}, 
            {"CoderRequestsOld", noInformationYet}, 
            {"CoderValues", noInformationYet}, 
            {"CoderWorkFlowData", noInformationYet}, 
            {"CoderWorkFlows", noInformationYet}, 
            {"CodingColumns", CodingColumns}, 
            {"CodingDictionaries", CodingDictionaries}, 
            {"CodingEntries", CodingEntries}, 
            {"CodingMap", noInformationYet}, 
            {"CodingRequestOdm", noInformationYet}, 
            {"CodingRequests", noInformationYet}, 
            {"CodingTermContextHash", noInformationYet}, 
            {"CodingValues", CodingValues}, 
            {"Comments_old", noInformationYet}, 
            {"ConfigLoaderColumns", ConfigLoaderColumns}, 
            {"ConfigLoaderExcelFiles", ConfigLoaderExcelFiles}, 
            {"ConfigLoaderLogs", ConfigLoaderLogs}, 
            {"ConfigLoaderWorksheets", ConfigLoaderWorksheets}, 
            {"Configuration", Configuration}, 
            {"CopiedSubjects", CopiedSubjects}, 
            {"Counters", noInformationYet}, 
            {"CRFFiles", CRFFiles}, 
            {"CRFVersions", CRFVersions}, 
            {"CrystalFieldLocales", crystalReportsUsage}, 
            {"CrystalFields", crystalReportsUsage}, 
            {"CrystalLabelLocales", crystalReportsUsage}, 
            {"CrystalLabels", crystalReportsUsage}, 
            {"CrystalLocalizations", crystalReportsUsage}, 
            {"CtmsSubjectDataAuditCategoryLookup", noInformationYet}, 
            {"CtmsSubjectMetricsAuditCategoryLookup", noInformationYet}, 
            {"CustomFunctions", CustomFunctions},
            #endregion
            #region D
            {"DataDictionaries", DataDictionaries}, 
            {"DataDictionaryEntries", DataDictionaryEntries}, 
            {"DataPages", DataPages}, 
            {"DataPointReviewStatus", DataPointReviewStatus}, 
            {"DataPoints", DataPoints}, 
            {"DataPointsDDE", DataPointsDDE}, 
            {"DataPointUntranslated", DataPointUntranslated}, 
            {"DCFQueries", dataClarificationForm}, 
            {"DCFs", dataClarificationForm}, 
            {"DCFStatus", dataClarificationForm}, 
            {"DCFStatusR", dataClarificationForm}, 
            {"DCFTransmissionContents", dataClarificationForm}, 
            {"DCFTransmissions", dataClarificationForm}, 
            {"DCFTransmissionTypes", dataClarificationForm}, 
            {"DDEBatches", doubleDataEntryBoilerplate}, 
            {"DDEBatchPages", doubleDataEntryBoilerplate}, 
            {"DDEControlMap", doubleDataEntryBoilerplate}, 
            {"DDEQueryComments", doubleDataEntryBoilerplate}, 
            {"DeletedChangeCodes", noInformationYet}, 
            {"DeletedConfigurations", noInformationYet}, 
            {"DeletedRoleActions", noInformationYet}, 
            {"DeletedUserGroups", noInformationYet}, 
            {"Derivations", Derivations}, 
            {"DerivationSteps", DerivationSteps}, 
            {"DesignObjectTypeR", DesignObjectTypeR}, 
            {"DifferenceMatchRules", migrationBoilerPlate}, 
            {"DifferencePropertyRules", migrationBoilerPlate}, 
            {"DryRunExecutionList", noInformationYet}, 
            {"DuplicateOIDLog", noInformationYet},
            #endregion
            #region E
            {"eLearningCourseLocaleFiles", noInformationYet}, 
            {"eLearningCourses", noInformationYet}, 
            {"eLearningCourseStudyRoles", noInformationYet}, 
            {"eLearningPostAssessmentAnswers", noInformationYet}, 
            {"eLearningPostAssessmentOptions", noInformationYet}, 
            {"eLearningPostAssessmentQuestions", noInformationYet}, 
            {"eLearningQuestionnaireQuestions", noInformationYet}, 
            {"eLearningQuestionnaires", noInformationYet}, 
            {"eLearningQuestionnaireUserAnswers", noInformationYet}, 
            {"eLearningUserCourses", noInformationYet}, 
            {"ElectronicSignatures", noInformationYet}, 
            {"EmailAddressTypeR", EmailAddressTypeR}, 
            {"EmailConfirmationLog", noInformationYet}, 
            {"EmailEventDetails", noInformationYet}, 
            {"EmailEventEmailAddress", noInformationYet}, 
            {"EmailEventSentEmails", noInformationYet}, 
            {"EmailEventTypeR", noInformationYet}, 
            {"EmailLog", noInformationYet}, 
            {"EmailRecipientTypeR", noInformationYet}, 
            {"Encryption", noInformationYet}, 
            {"EntryStatusR", noInformationYet}, 
            {"EventQueues", noInformationYet}, 
            {"EventQueuesObjects", noInformationYet}, 
            {"ExternalSystems", ExternalSystems}, 
            {"ExternalUserCourses", noInformationYet}, 
            {"ExternalUserRoles", noInformationYet}, 
            {"ExternalUsers", noInformationYet}, 
            {"ExternalUserSecurityGroups", noInformationYet}, 
            {"ExternalUserUserGroups", noInformationYet},
            #endregion
            #region F
            {"FieldOIDDirectory", noInformationYet}, 
            {"FieldRestrictEntries_old", noInformationYet}, 
            {"FieldRestrictions", FieldRestrictions}, 
            {"FieldRestrictViews_old", noInformationYet}, 
            {"FieldReviewGroups", FieldReviewGroups}, 
            {"Fields", Fields}, 
            {"FolderForms", FolderForms}, 
            {"Folders", Folders}, 
            {"FormRestrictEntries_old", noInformationYet}, 
            {"FormRestrictions", FormRestrictions}, 
            {"FormRestrictViews_old", noInformationYet}, 
            {"Forms", Forms},
            #endregion
            #region H
            {"HelpPages", HelpPages}, 
            #endregion
            #region I
            {"IdentifierTypeR", noInformationYet}, 
            {"Images", noInformationYet}, 
            {"ImageTypeR", noInformationYet}, 
            {"ImpliedActionTypes", noInformationYet}, 
            {"InstalledModules", noInformationYet}, 
            {"Instances", Instances}, 
            {"Interactions", Interactions}, 
            {"InteractionStatusR", InteractionStatusR},
            #endregion
            #region J
            {"JPMSColumnContents", noInformationYet}, 
            {"JPMSColumnContentTypeR", noInformationYet}, 
            {"JPMSColumnDataTypeR", noInformationYet}, 
            {"JPMSColumns", noInformationYet}, 
            {"JPMSEnrollmentPercentages", noInformationYet}, 
            {"JPMSModeTypeR", noInformationYet}, 
            {"JPMSProperties", noInformationYet}, 
            {"JRDATABROWSER", noInformationYet},
            #endregion
            #region L
            {"LabAssignments", noInformationYet}, 
            {"Labs", noInformationYet}, 
            {"LabStandardGroupEntries", noInformationYet}, 
            {"LabStandardGroups", noInformationYet}, 
            {"LabUnitConversions", noInformationYet}, 
            {"LabUnitDictionaries", noInformationYet}, 
            {"LabUnitDictionaryEntries", noInformationYet}, 
            {"LabUnits", noInformationYet}, 
            {"LabUpdateQueue", noInformationYet}, 
            {"LibraryIcons", noInformationYet}, 
            {"LocalizationContexts", noInformationYet}, 
            {"Localizations", Localizations}, 
            {"LocalizedDataStringPKs", noInformationYet}, 
            {"LocalizedDataStrings", LocalizedDataStrings}, 
            {"LocalizedStrings", LocalizedStrings}, 
            {"LockStatusR", LockStatusR}, 
            {"LogicalRecordPositionR", noInformationYet}, 
            {"LoginAttempts", LoginAttempts},
            #endregion
            #region M
            {"MarkingGroupCategoryR", MarkingGroupCategoryR}, 
            {"MarkingGroups", MarkingGroups}, 
            {"Markings", Markings}, 
            {"MarkingTypeR", MarkingTypeR}, 
            {"Matrix", Matrix}, 
            {"MatrixActionR", noInformationYet}, 
            {"MessageRecipients", noInformationYet}, 
            {"Messages", noInformationYet}, 
            {"MigrationCheckActions", migrationBoilerPlate}, 
            {"MigrationChecks", migrationBoilerPlate}, 
            {"MigrationChecksRunInJob", migrationBoilerPlate}, 
            {"MigrationConfiguration", migrationBoilerPlate}, 
            {"MigrationControl", migrationBoilerPlate}, 
            {"MigrationEventAudits", migrationBoilerPlate}, 
            {"MigrationFailedCheckLog", migrationBoilerPlate}, 
            {"MigrationFolderForms", migrationBoilerPlate}, 
            {"MigrationFolderFormsDropInJob", migrationBoilerPlate}, 
            {"MigrationInPlace", migrationBoilerPlate}, 
            {"MigrationIssues", migrationBoilerPlate}, 
            {"MigrationIssueTypeR", migrationBoilerPlate}, 
            {"MigrationJobTypeR", migrationBoilerPlate}, 
            {"MigrationLibraryObjectAudits", migrationBoilerPlate}, 
            {"MigrationMapIssues", migrationBoilerPlate}, 
            {"MigrationMapSourceR", migrationBoilerPlate}, 
            {"MigrationMergeMatrix", migrationBoilerPlate}, 
            {"MigrationObjectMap", migrationBoilerPlate}, 
            {"MigrationOHMatrixChangeRules", migrationBoilerPlate}, 
            {"MigrationPlan", migrationBoilerPlate}, 
            {"MigrationReferenceMap", migrationBoilerPlate}, 
            {"MigrationRun", migrationBoilerPlate}, 
            {"MigrationRunCheckRef", migrationBoilerPlate}, 
            {"MigrationRunSchedule", migrationBoilerPlate}, 
            {"MigrationRunTypeR", migrationBoilerPlate}, 
            {"MigrationSchedulerConfiguration", migrationBoilerPlate}, 
            {"MigrationSchedulerMessages", migrationBoilerPlate}, 
            {"MigrationSchedulerMessagesHistory", migrationBoilerPlate}, 
            {"MigrationSchedulerMessageTypeR", migrationBoilerPlate}, 
            {"MigrationSchedulerStatusR", migrationBoilerPlate}, 
            {"MigrationSchedulerTaskQueue", migrationBoilerPlate}, 
            {"MigrationSchedulerTaskQueueHistory", migrationBoilerPlate}, 
            {"MigrationSchedulerTaskStatusR", migrationBoilerPlate}, 
            {"MigrationServiceRoleR", migrationBoilerPlate}, 
            {"MigrationServiceRunStateR", migrationBoilerPlate}, 
            {"MigrationServices", migrationBoilerPlate}, 
            {"MigrationStepTypeR", migrationBoilerPlate}, 
            {"MigrationSubjectList", migrationBoilerPlate}, 
            {"MigrationSubjectSelections", migrationBoilerPlate}, 
            {"MissingCodes", MissingCodes}, 
            {"ModuleActions", ModuleActions}, 
            {"ModulePages", ModulePages}, 
            {"ModulesR", ModulesR},
            #endregion
            #region N
            {"NewLogins", noInformationYet},
            #endregion
            #region O
            {"ObjectLocks", ObjectLocks}, 
            {"ObjectStatusAllRoles", ObjectStatusAllRoles}, 
            {"ObjectStatusR", ObjectStatusR}, 
            {"ObjectTagAlerts", noInformationYet}, 
            {"ObjectTagQualifiers", noInformationYet}, 
            {"ObjectTags", noInformationYet}, 
            {"ObjectTags2", noInformationYet}, 
            {"ObjectTypeR", noInformationYet}, 
            {"OldPasswords", noInformationYet}, 
            {"OldSubjectStudySites", noInformationYet}, 
            {"OmniLoader_XSLTTransforms", noInformationYet}, 
            {"OmniLoaderRegisteredLoaders", noInformationYet}, 
            {"OmniLoaderSilentUploadTrail", noInformationYet}, 
            {"OmniLoaderStatusHash", noInformationYet}, 
            #endregion
            #region P
            {"PageStatusMetrics", noInformationYet}, 
            {"PageStatusMetricsUsers", noInformationYet}, 
            {"ParameterPrerequisites", noInformationYet}, 
            {"Parameters", noInformationYet}, 
            {"ParameterScopeR", noInformationYet}, 
            {"ParameterTypeR", noInformationYet}, 
            {"PasswordReactivations", noInformationYet}, 
            {"PDFConfiguration", noInformationYet}, 
            {"PDFConfigurationProfiles", noInformationYet}, 
            {"PdfErrorLog", noInformationYet}, 
            {"PDFFileRequests", noInformationYet}, 
            {"PendingSubjects", noInformationYet}, 
            {"PermissionR", noInformationYet}, 
            {"PlannedEnrollments", noInformationYet}, 
            {"PossibleLocales", noInformationYet}, 
            {"ProjectCoderRegistration", noInformationYet}, 
            {"ProjectCoderRegistrationWorkFlow", noInformationYet}, 
            {"Projects", noInformationYet}, 
            {"ProtocolDeviationClassR", noInformationYet}, 
            {"ProtocolDeviationCodeR", noInformationYet}, 
            {"ProtocolDeviations_old", noInformationYet},
            #endregion
            #region Q
            {"QAuditDataCategoryLookup", noInformationYet}, 
            {"Queries_old", noInformationYet}, 
            {"QueryStatusR", noInformationYet},
            #endregion
            #region R
            {"RangeTypes", noInformationYet}, 
            {"RangeTypeVariables", noInformationYet}, 
            {"RaveAddonInstallParams", noInformationYet}, 
            {"RaveAddons", noInformationYet}, 
            {"RavePatches", noInformationYet}, 
            {"RCVs", noInformationYet}, 
            {"RCVSesLog", noInformationYet}, 
            {"RCVSesRequests", noInformationYet}, 
            {"RCVSessions", noInformationYet}, 
            {"ReasonCodes", noInformationYet}, 
            {"Records", noInformationYet}, 
            {"RenderingTypeR", noInformationYet}, 
            {"ReportFiles", noInformationYet}, 
            {"ReportingLabDataPoints", noInformationYet}, 
            {"ReportingLabDPDeletes", noInformationYet}, 
            {"ReportingRecordDeletes", noInformationYet}, 
            {"ReportingRecords", noInformationYet}, 
            {"ReportingRecordsExt", noInformationYet}, 
            {"ReportLocalizedStrings", noInformationYet}, 
            {"ReportMatrices", noInformationYet}, 
            {"ReportParameters", noInformationYet}, 
            {"ReportRequests", noInformationYet}, 
            {"Reports", noInformationYet}, 
            {"ReportSortings", noInformationYet}, 
            {"ReportStudyFilters", noInformationYet}, 
            {"ReportTypeR", noInformationYet}, 
            {"Resources", noInformationYet}, 
            {"RestrictionTypeR", noInformationYet}, 
            {"ReviewGroups", noInformationYet}, 
            {"ReviewStatusR", noInformationYet}, 
            {"RISS_IntegratedApplicationsConfigurations", noInformationYet}, 
            {"RISS_MessageDeliveryTypes", noInformationYet}, 
            {"RISS_UnprocessedMessages", noInformationYet}, 
            {"RoleActions", RoleActions}, 
            {"RolePermissionR", noInformationYet}, 
            {"RolesAllModules", RolesAllModules}, 
            {"RoleSubjectStatusAccess", noInformationYet}, 
            {"RptEncryption", noInformationYet}, 
            {"RptPackageReportFiles", noInformationYet}, 
            {"RptPackageReports", noInformationYet}, 
            {"RptPackages", noInformationYet}, 
            {"RSGMan_AcknowledgementFiles", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_AdminAuditArguments", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_AdminAudits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Arrivals", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Cases", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_EmailTemplates", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_ExtractDiagnosticParameters", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_ExtractDiagnostics", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Messages", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_NarrativeAudits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Patients", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_ProjectConfigurations", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Pulse", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Records", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_RecordTagValues", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_RecordValues", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_SafetyReports", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_SelectionAudits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Selections", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_SharedConfiguration", raveSafetyGatewayBoilerPlate}, 
            {"RSGMan_Version", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_AdminAuditArguments", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_AdminAudits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_Audits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_Configurations", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_DictionaryItemMappings", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_E2BDictionariesR", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_E2BDictionaryItemsR", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_EmailTemplates", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorAllowedTransactionTypeR", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorConfigs", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorConfigsAux", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorConfigsRWS", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorDiagnostics", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorDiagnosticsParameters", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorEventQueues", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorHistories", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorSendQueue", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorSendQueueErrorMessages", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorStaging", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorTags", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ExtractorTransformations", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_FieldMappings", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_FormMappings", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_MappingConfiguration", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_MonitorSubjectsQueue", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ProjectAudits", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_ProjectTags", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_Pulse", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_SafetyCaseNumbers", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_StudyConfigurations", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_TagGroupsR", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_TagsR", raveSafetyGatewayBoilerPlate}, 
            {"RSGMap_Version", raveSafetyGatewayBoilerPlate}, 
            {"RWSCDSAuditDataExtractionLog", noInformationYet},
            #endregion
            #region S
            {"SASonDemand_Jobs", noInformationYet}, 
            {"SASonDemand_OutputFileTypes", noInformationYet}, 
            {"SASonDemand_RequestedViews", noInformationYet}, 
            {"ScriptExecutionLog", noInformationYet}, 
            {"ScriptUtilityIssues", noInformationYet}, 
            {"ScriptUtilityParamControls", noInformationYet}, 
            {"ScriptUtilityRunParameters", noInformationYet}, 
            {"ScriptUtilityRuns", noInformationYet}, 
            {"ScriptUtilityTypeParams", noInformationYet}, 
            {"ScriptUtilityTypes", noInformationYet}, 
            {"SecurityGroup", noInformationYet}, 
            {"SecurityGroupUser", noInformationYet}, 
            {"SelectionStyleR", noInformationYet}, 
            {"Servers", noInformationYet}, 
            {"SharedSubjects", noInformationYet}, 
            {"SharingRelationships", noInformationYet}, 
            {"Signatures", noInformationYet}, 
            {"SiteGroups", noInformationYet}, 
            {"SiteMonPrimaryInvestigators", noInformationYet}, 
            {"SiteMonStudyInformation", noInformationYet}, 
            {"SiteMonStudySites", noInformationYet}, 
            {"Sites", noInformationYet}, 
            {"StatusRollupLog", noInformationYet}, 
            {"StatusRollupQueue", noInformationYet}, 
            {"Stickies_old", noInformationYet}, 
            {"StickyStatusR", noInformationYet}, 
            {"StringTokenR", noInformationYet}, 
            {"Studies", noInformationYet}, 
            {"StudySiteInvestigators", noInformationYet}, 
            {"StudySites", noInformationYet}, 
            {"StudySiteSyncLog", noInformationYet}, 
            {"SubjectMatrix", noInformationYet}, 
            {"Subjects", noInformationYet}, 
            {"SubjectStatus", noInformationYet}, 
            {"SubjectStatusCategoryR", noInformationYet}, 
            {"SubjectStatusHistory", noInformationYet}, 
            {"SuspectRoles", noInformationYet}, 
            {"Synchronizations", noInformationYet},
            #endregion
            #region T
            {"TagAlerts", noInformationYet}, 
            {"TagDataTypeR", noInformationYet}, 
            {"TagDetails", noInformationYet}, 
            {"TagProcessorDeployments", noInformationYet}, 
            {"TagProcessors", noInformationYet}, 
            {"Tags", noInformationYet}, 
            {"TaskProgress", noInformationYet}, 
            {"TemplateFields", noInformationYet}, 
            {"Templates", noInformationYet}, 
            {"TimeStampTypeR", noInformationYet}, 
            {"Timezones", noInformationYet}, 
            {"TSDV_BlockPlanEnvironments", noInformationYet}, 
            {"TSDV_BlockPlanRules", noInformationYet}, 
            {"TSDV_BlockPlans", noInformationYet}, 
            {"TSDV_Blocks", noInformationYet}, 
            {"TSDV_BlockSubjects", noInformationYet}, 
            {"TSDV_BlockTiers", noInformationYet}, 
            {"TSDV_CustomTiers", noInformationYet}, 
            {"TSDV_ExcludedSubjectStatuses", noInformationYet}, 
            {"TSDV_FormFields", noInformationYet}, 
            {"TSDV_PublishedDraftTiers", noInformationYet}, 
            {"TSDV_RuleActions", noInformationYet}, 
            {"TSDV_RuleActionTypesR", noInformationYet}, 
            {"TSDV_Rules", noInformationYet}, 
            {"TSDV_RuleSteps", noInformationYet}, 
            {"TSDV_RuleTypesR", noInformationYet}, 
            {"TSDV_SiteBlocks", noInformationYet}, 
            {"TSDV_TierFormFolders", noInformationYet}, 
            {"TSDV_TierForms", noInformationYet}, 
            {"TSDV_TierTypeR", noInformationYet},
            #endregion
            #region U
            {"UnitDictionaries", UnitDictionaries}, 
            {"UnitDictionaryEntries", UnitDictionaryEntries}, 
            {"UploadCollectionProviderTypeR", batchUploaderBoilerPlate + UploadCollectionProviderTypeR}, 
            {"UploadComments", batchUploaderBoilerPlate}, 
            {"UploadDataPoints", batchUploaderBoilerPlate}, 
            {"UploadDirectories", batchUploaderBoilerPlate + UploadDirectories}, 
            {"UploadedFileRecords", batchUploaderBoilerPlate}, 
            {"UploadedRecords", batchUploaderBoilerPlate}, 
            {"UploadEmailConfigs", batchUploaderBoilerPlate}, 
            {"UploadEmailTypeR", batchUploaderBoilerPlate}, 
            {"UploadErrorR", batchUploaderBoilerPlate}, 
            {"UploadErrorTypeR", batchUploaderBoilerPlate}, 
            {"UploadFileConfigs", batchUploaderBoilerPlate + UploadFileConfigs}, 
            {"UploadFileRecords", batchUploaderBoilerPlate}, 
            {"UploadFiles", batchUploaderBoilerPlate + UploadFiles}, 
            {"UploadFileTypeR", batchUploaderBoilerPlate + UploadFileTypeR}, 
            {"UploadIncrOrFullR", batchUploaderBoilerPlate + UploadIncrOrFullR}, 
            {"UploadMappings", batchUploaderBoilerPlate}, 
            {"UploadMessages", batchUploaderBoilerPlate}, 
            {"UploadMessageTypeR", batchUploaderBoilerPlate}, 
            {"UploadMissingRecordsProcessingR", batchUploaderBoilerPlate}, 
            {"UploadProcessingTypeR", batchUploaderBoilerPlate}, 
            {"UploadProcessorR", batchUploaderBoilerPlate}, 
            {"UploadProjectConfigs", batchUploaderBoilerPlate + UploadProjectConfigs}, 
            {"UploadQueries", batchUploaderBoilerPlate}, 
            {"UploadQueryActionR", batchUploaderBoilerPlate}, 
            {"UploadRecords", batchUploaderBoilerPlate}, 
            {"UploadReferenceTypeR", batchUploaderBoilerPlate}, 
            {"UploadServices", batchUploaderBoilerPlate + UploadServices}, 
            {"UploadServiceStatusR", batchUploaderBoilerPlate + UploadServiceStatusR}, 
            {"UploadSteps", batchUploaderBoilerPlate}, 
            {"UploadStickies", batchUploaderBoilerPlate}, 
            {"UploadStringR", batchUploaderBoilerPlate}, 
            {"UploadStringTypeR", batchUploaderBoilerPlate}, 
            {"UploadStudyConfigs", batchUploaderBoilerPlate + UploadStudyConfigs}, 
            {"UploadStudySettings", batchUploaderBoilerPlate}, 
            {"UploadStudyThreads", batchUploaderBoilerPlate + UploadStudyThreads}, 
            {"UploadTcpRequestCommandR", batchUploaderBoilerPlate}, 
            {"UploadTcpRequests", batchUploaderBoilerPlate}, 
            {"UploadTcpRequestStatusR", batchUploaderBoilerPlate}, 
            {"UploadThreads", batchUploaderBoilerPlate + UploadThreads}, 
            {"UploadTransformations", batchUploaderBoilerPlate}, 
            {"UploadXslTransformations", batchUploaderBoilerPlate}, 
            {"UserAuditQueue", UserAuditQueue}, 
            {"UserGroups", UserGroups}, 
            {"UserModules", UserModules}, 
            {"UserObjectRole", UserObjectRole}, 
            {"UserPermissionHistory", UserPermissionHistory}, 
            {"UserPermissionTypeR", UserPermissionTypeR}, 
            {"UserReportProfiles", noInformationYet}, 
            {"UserRoleReports", noInformationYet}, 
            {"Users", Users}, 
            {"UserSettings", UserSettings}, 
            {"UserStudySites", UserStudySites}, 
            #endregion
            #region V
            {"VariableChangeAudits", noInformationYet}, 
            {"Variables", noInformationYet}, 
            {"VerifyStatusR", noInformationYet}, 
            {"VersionRangeTypes", noInformationYet}, 
            {"VersionVariableMappings", noInformationYet}, 
            #endregion
            #region W
            {"WebServicesApplicationUsers", noInformationYet}, 
            {"WebServicesAttributes", noInformationYet}, 
            {"WebServicesAuthenticationTokens", noInformationYet}, 
            {"WebServicesConfigurableDatasetConfiguration", noInformationYet}, 
            {"WebServicesConfigurableDatasetFormats", noInformationYet}, 
            {"WebServicesConfigurableDatasetFormatTypeR", noInformationYet}, 
            {"WebServicesConfigurableDatasetObjects", noInformationYet}, 
            {"WebServicesErrorTypeR", noInformationYet}, 
            {"WebServicesFormats", noInformationYet}, 
            {"WebServicesHTTPResponseCodeR", noInformationYet}, 
            {"WebServicesLogInbound", noInformationYet}, 
            {"WebServicesNameSpaces", noInformationYet}, 
            {"WebServicesObjectAttributes", noInformationYet}, 
            {"WebServicesObjects", noInformationYet}, 
            {"WebServicesProcessors", noInformationYet}, 
            {"WebServicesRequestProcessors", noInformationYet}, 
            {"WebServicesRoles", noInformationYet}, 
            {"WebServicesTransformations", noInformationYet}, 
            {"WebServicesUserRoles", noInformationYet}, 
            {"WebServicesWarningsInbound", noInformationYet}, 
            {"WebServicesWarningTypeR", noInformationYet}, 
            {"WelcomeMessageLevelR", noInformationYet}, 
            {"WelcomeMessageRoles", noInformationYet}, 
            {"WelcomeMessages", noInformationYet}, 
            {"WelcomeMessageStudies", noInformationYet}, 
            {"WelcomeMessageTags", noInformationYet}, 
            {"WHODrug", noInformationYet}
            #endregion
        };
    }
}
