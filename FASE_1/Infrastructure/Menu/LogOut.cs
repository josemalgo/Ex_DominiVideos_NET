
namespace FASE_1.Infrastructure.Menu
{
    class LogOut : Option
    {
        private App _app;
        private bool _executed;

        public LogOut(App app)
            :base("Tancar sessió.")
        {
            _app = app;
        }

        public override void Execute()
        {
            _app.CurrentUser = null;
            _executed = true;
        }

        public bool Executed()
        {
            return _executed;
        }
    }
}
