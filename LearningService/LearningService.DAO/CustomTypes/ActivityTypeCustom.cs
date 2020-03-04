namespace LearningService.DAO.CustomTypes
{
    public enum ActivityTypeCustom
    {
        AccountCreated = 1,
        AccountLoggedIn,
        AccountLogOut,
        ArticleOwnManagement,
        ArticleRead,
        CourseAdded,
        LessonOwnManagement,
        CourseSubscription,
        LessonPassed,
        MailNotification, //wyslales maila do .. z kursu ..
        AccountManagement //edited password, account
    }
}
