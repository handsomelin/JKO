using System;
namespace Request
{
    public static class Actions
    {
        public static Register register = new Register();
        public static CreateListing createListing = new CreateListing();
        public static DeleteListing deleteListing = new DeleteListing();
        public static GetListing getListing = new GetListing();
        public static GetCategory getCategory = new GetCategory();
        public static GetTopCategory getTopCategory = new GetTopCategory();
        public static Invalid invalid = new Invalid();
    }
}
