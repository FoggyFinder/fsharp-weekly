module Types

type Link = {
    Url : string
    Content : string
}

type Category = {
    Name: string
    Links: Link list
}

type BlogEntry = {
    Title: string
    WeekNumber: string
    Categories: Category list
}

type GithubRepository = {
    Name : string 
    Owner: string
    Url : string
    Description: string
    StarCount: int
}

type StackoverflowQuestion = {
    Title : string
    Url : string
    IsAnswered : bool
    Answers : int
    Views : int
}

type Remote<'t> =
    | Empty
    | Loading
    | LoadError of string
    | Content of 't

type State = {
    Blogs: Remote<BlogEntry list>
    TrendyGithubRepositories : Remote<GithubRepository list>
    StackoverflowQuestions : Remote<StackoverflowQuestion list>
    CurrentBlog : Option<BlogEntry>
    ShowingSettings : bool
    VisitedLinks : string list
    LinkTrackingEnabled : bool
}

type Msg =
    | LoadBlogs
    | BlogsLoaded of BlogEntry list
    | BlogsLoadFailure of string
    | SelectBlog of BlogEntry
    | OpenUrl of string
    | PoppedPage of string
    | ShowSettings
    | ToggleLinkTracking
    | ClearVisitedLinks
    | LoadRepos
    | ReposLoaded of GithubRepository list
    | ReposLoadFailure of string
    | PageIndexChanged of int
    | LoadQuestions
    | QuestionsLoaded of StackoverflowQuestion list
    | QuestionsLoadFailure of string