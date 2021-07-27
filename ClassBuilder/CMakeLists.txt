target_sources(${CMAKE_PROJECT_NAME} PRIVATE
	"ClassBuilder.cs"
)

add_subdirectory(Generator)
add_subdirectory(Project)
add_subdirectory(UI)