target_sources(${CMAKE_PROJECT_NAME} PRIVATE
	"ClassBuilder.cs"
)

add_subdirectory(Generator)
add_subdirectory(CLI)
add_subdirectory(Data)
add_subdirectory(UI)