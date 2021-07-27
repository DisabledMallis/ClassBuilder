cmake_minimum_required(VERSION 3.17)
project(ClassBuilder VERSION 0.1.0 LANGUAGES CSharp)

# Create an executable
add_executable(${CMAKE_PROJECT_NAME})

# Set the C# language version to 9
set_target_properties(${CMAKE_PROJECT_NAME} PROPERTIES VS_GLOBAL_LangVersion "9.0")

# Set configuration properties
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.8")
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY WIN32_EXECUTABLE FALSE)
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_CONFIGURATION_TYPE Console)
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_DOTNET_REFERENCES_COPY_LOCAL OFF)

# Add references
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_DOTNET_REFERENCES
	"Microsoft.CSharp"
	"System"
	"System.Core"
	"System.Data"
	"System.Drawing"
	"System.Windows.Forms"
	"${CMAKE_CURRENT_LIST_DIR}/Lib/Newtonsoft.Json.dll"
)

# Add sources
add_subdirectory(ClassBuilder)