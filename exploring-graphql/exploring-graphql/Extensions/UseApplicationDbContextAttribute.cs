using exploring_graphql.Data;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace exploring_graphql.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context, 
            IObjectFieldDescriptor descriptor, 
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
