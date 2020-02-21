using System;

namespace KataTrainReservation
{
    public abstract class Result
    {
        public abstract bool IfFound();

        public static Result WasSucces(Coach coach)
        {
            return new Success(coach);
        }

        public static Result WasFail(string errorMessage)
        {
            return new Fail(errorMessage);
        }

        private sealed class Success : Result, IEquatable<Success>
        {
            public override bool IfFound() => true;

            public bool Equals(Success other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(Coach, other.Coach);
            }

            public override bool Equals(object obj)
            {
                return ReferenceEquals(this, obj) || obj is Success other && Equals(other);
            }

            public override int GetHashCode()
            {
                return (Coach != null ? Coach.GetHashCode() : 0);
            }

            public static bool operator ==(Success left, Success right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Success left, Success right)
            {
                return !Equals(left, right);
            }

            public Coach Coach { get; }
            internal Success(Coach coach) => this.Coach = coach;
        }

        private sealed class Fail : Result, IEquatable<Fail>
        {
            public override bool IfFound() => false;

            public bool Equals(Fail other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return ErrorMessage == other.ErrorMessage;
            }

            public override bool Equals(object obj)
            {
                return ReferenceEquals(this, obj) || obj is Fail other && Equals(other);
            }

            public override int GetHashCode()
            {
                return (ErrorMessage != null ? ErrorMessage.GetHashCode() : 0);
            }

            public static bool operator ==(Fail left, Fail right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Fail left, Fail right)
            {
                return !Equals(left, right);
            }

            public string ErrorMessage { get; }
            internal Fail(string errorMessage) => this.ErrorMessage = errorMessage;
        }
    }
}