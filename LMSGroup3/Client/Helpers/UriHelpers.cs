namespace LMSGroup3.Client.Helpers
{
    public class UriHelpers

    {
        public const string ModuleDetails = $"/ModuleDetails/{{Id:int}}";
        public const string ModuleUpdate = $"/ModuleUpdate/{{Id:int}}";
        public const string ModuleAdd = $"/ModuleAdd/{{courseId:int}}";
        public const string ModuleDelete = $"/Moduleelete/{{Id:int}}";
        public static string GetModuleAddUri<T>(T courseId) => $"/moduleadd/{courseId}";
        public static string GetModuleUpdateUri<T>(T moduleId) => $"/moduleupdate/{moduleId}";
        public static string GetModuleDeleteUri<T>(T moduleId) => $"/moduledelete/{moduleId}";
        public static string GetModuleDetailsUri<T>(T moduleId) => $"/moduledetails/{moduleId}";

        public static string ModulesBaseUri => "api/modules/";

        public static string GetModuleUri<T>(T moduleId, bool includeActivities = false)
        {
            return ModulesBaseUri + moduleId!.ToString() + $"?includeActivities={includeActivities}";
        }

        public static string GetModulesUri()
        {   
            return ModulesBaseUri;
        }




    }


}
