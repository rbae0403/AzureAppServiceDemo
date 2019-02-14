using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace DemoAzureBlob.Filters
{
    /// <summary>
    /// FileUploadOperationFilter
    /// </summary>
    /// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
    public class FileUploadOperationFilter : IOperationFilter
    {
        /// <summary>
        /// The file upload parameter name
        /// </summary>
        private static readonly string FileUploadParamName = "file";

        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="apiDescription">The API description.</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.ActionDescriptor.ActionName.Contains("File"))
            {
                if (operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }

                var parameter = new Parameter()
                {
                    @in = "formData",
                    type = "file",
                    name = "File",
                    description = "Upload"
                };
                operation.parameters.Add(parameter);
                operation.consumes.Add("multipart/form-data");
            }
            else
            {
                var paramDescList = apiDescription
                    .ParameterDescriptions
                    .Where(x => x.Name.ToLower().Contains(FileUploadOperationFilter.FileUploadParamName))
                    .ToList();
                var paramDescCount = paramDescList.Count();
                if (paramDescList.Count() > 0)
                {
                    var paramList = operation
                        .parameters
                        .Where(x => x.name.ToLower().Contains(FileUploadOperationFilter.FileUploadParamName))
                        .ToList();
                    int paramListCount = paramList.Count();
                    if (paramListCount == paramDescCount)
                    {
                        var nameMap = new Dictionary<string, byte>();
                        for (int i = 0; i < paramListCount; i++)
                        {
                            string fieldName = paramDescList[i].ParameterDescriptor.DefaultValue.ToString();
                            if (string.IsNullOrEmpty(fieldName))
                            {
                                fieldName = "File";
                            }
                            else
                            {
                                fieldName = fieldName.Replace(" ", string.Empty);
                            }

                            // Check whether the field name is duplicate
                            if (nameMap.ContainsKey(fieldName))
                            {
                                byte n = nameMap[fieldName];
                                fieldName = $"{fieldName}{++n}";
                                nameMap.Add(fieldName, n);
                            }
                            else
                            {
                                nameMap.Add(fieldName, 1);
                            }

                            paramList[i].@in = "formData";
                            paramList[i].type = "file";
                            paramList[i].name = fieldName;
                            if (string.IsNullOrEmpty(paramList[i].description))
                            {
                                paramList[i].description = "Upload";
                            }
                        }

                        operation.consumes.Add("multipart/form-data");
                    }
                }
            }
        }
    }
}