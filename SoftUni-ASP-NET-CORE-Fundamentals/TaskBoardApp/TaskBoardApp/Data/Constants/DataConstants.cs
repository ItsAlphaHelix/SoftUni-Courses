namespace TaskBoardApp.Data.Constants
{
    public class DataConstants
    {
        public class User
        {
            public const int MaxUserFirstName = 15;
            public const int MinUserFirstName = 5;

            public const int MaxUserLastName = 15;
            public const int MinUserLastName = 5;

            public const int MaxUserUsername = 20;
            public const int MinUserUsername = 5;
        }

        public class Task
        {
            public const int MaxTaskTitle = 70;
            public const int MinTaskTitle = 5;

            public const int MaxTaskDescription = 70;
            public const int MaxtaskDescription = 10;
        }

        public class Board
        {
            public const int MaxBoardName = 30;
            public const int MinBoardName = 3;
        }
    }
}
