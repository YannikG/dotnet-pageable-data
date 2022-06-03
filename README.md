# Nuget Repo Template

This repository is provided as a template repository for the creation of Nuget packages. It contains build and deploy scripts that are executed by the Github Actions feature when code is published to a remote repository that is based of this template. This template is primarily designed for the building of class libraries targetting `netstandard2.0`.

## Dependencies
1. Github build agent to run the pipeline

## Getting started

Following instructions are targeted at bash shell (as per git-bash)

1. Create a new repository via the Aqovia Github site using the  [here](https://github.com/organizations/Aqovia/repositories/new)
    - Select the `nuget-repo-template` as the starter template for the repo
    - Give the repo a unique name eg new-nuget-repo
2. Clone the new repo to your local machine using the standard git mechanism
    - `git clone https://github.com/Aqovia/new-nuget-repo.git`
3. Move into the new repository
    - `cd new-nuget-repo`
4. Set up the project - substitute {YOUR_NEW_PROJECT_NAME} with the correct project name
```bash
NEW_PROJECT={YOUR_NEW_PROJECT_NAME}
mkdir src src/$NEW_PROJECT
dotnet new sln -n $NEW_PROJECT
pushd src/$NEW_PROJECT && dotnet new classlib --framework "netstandard2.0" && popd
dotnet sln add src/$NEW_PROJECT/$NEW_PROJECT.csproj
```
5. If tests are required (example setup) - from the repo root
```bash
NEW_TEST_PROJECT={YOUR_NEW_TEST_PROJECT_NAME}
mkdir test test/$NEW_TEST_PROJECT
pushd test/$NEW_TEST_PROJECT && dotnet new mstest && popd
dotnet sln add test/$NEW_TEST_PROJECT/$NEW_TEST_PROJECT.csproj
``` 
6. Setup the new project to be packages for Nuget repositories
    - set the following in the classlib csproj file
```xml
	<PropertyGroup>
		<!-- General -->
		<AssemblyName>{YOUR_ASSEMBLY_NAME_GOES_HERE_IF_NEEDED}</AssemblyName>
		<TargetFramework>netstandard2.0</TargetFramework>
		<Description>{YOUR_DESCRIPTION_GOES_HERE}</Description>
		<Copyright>{COPYRIGHT_INFO}</Copyright>
		<Authors>{Author}</Authors>
		<NeutralLanguage>{Language code}</NeutralLanguage>

		<!-- NuGet settings -->
		<PackageId>{YOUR_PUBLISHED_PACKAGE_NAME}</PackageId>
		<PackageTags>{TAGS_FOR_YOUR_PACKAGE}</PackageTags>
		<PackageLicenseExpression>{YOUR_LICENSE}</PackageLicenseExpression>
		<PackageRequireLicenseAcceptance>true</PackageRequireLicenseAcceptance>
		<PackageProjectUrl>{LINK_TO_YOUR_REPOSITORY_GOES_HERE}</PackageProjectUrl>
		<IsPackable>true</IsPackable>
		<RepositoryType>git</RepositoryType>
    	<RepositoryUrl>{LINK_TO_YOUR_REPOSITORY_GOES_HERE}</RepositoryUrl>
		
	</PropertyGroup>
```

7. Configure the CI Pipeline
    - open the file `.github/workflows/pipelines.yml`
    - set these variables in the `env` section of the file - set only the variables shown and leave others as they are
```yaml
env:
  ### This is your new library project name
  PROJECT_NAME: {YOUR_NEW_PROJECT_NAME}
  
  ### This is your new library test project name
  TEST_PROJECT_NAME: {YOUR_TEST_PROJECT_NAME}

  ### A nuget feed which will maintain preview builds
  NUGET_PREVIEW_FEED: {YOUR_NUGET_PREVIEW_FEED}

  ### A nuget feed which will maintain release builds ie Nuget.org
  NUGET_FEED: {YOUR_NUGET_RELEASE_FEED}
```

8. Go to your organisation/repository settings and add the following secrets (PATS for your relevant feed accounts)
    - `NUGET_PREVIEW_FEED_PUBLISH_KEY`
    - `NUGET_ORG_PUBLISH_API_KEY`

8. Replace the `README.md` (this file) with a relevant README for your project

9. Commit your changes
```bash
git add -A
git commit -m "Initial project setup and config"
git push
```
10. Observe the building of the project on the remote server by going to the Gihub Actions tab in the remote repo ui
11. Create features by branching from the `master` branch
12. Once completed push the changes to the remote and observe the remote build of the branch
    - the CI will create a preview build and push this to the Preview Feed for testing
13. Once finalised create a pull request to `master` branch via the Github UI
    - there is functionality to parse and extract this PR title and description for usage during release process
    - all successful PRs to master are intended to publish a new semantic version of the project to the release Nuget feed
    - in order to inform the CI pipeline of what your intended semantic version update should be for this change (pr to master) you should include 1 of the following strings in the PR description
        1. bump: major
            - this will bump the major version during the release process
        2. bump: minor
            - this will bump the minor version during the release process
        3. bump: patch
            - this will bump the patch version during the release process
            - if no matching bump message is found the PR will be rejected (TODO: PR format checker prior to pull request merge)
    - the Release note (found via the github Releases link) will be automatically updated using the information provided in the PR message
        - the title of the PR will become a new heading
        - the description of the message (and all markdown) will become the content under the heading

## Further note
1. It was intended that a Github workflow template might be better suited for the maintainance of the workflow and actions contained in this repository. Due to time constraints and the no availability of action templates at the time of writing this was not possible. In order to best encapsulate the workflow and associated actions this repository template was considered the most effective option. 






