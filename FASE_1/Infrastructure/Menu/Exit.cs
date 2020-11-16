

namespace FASE_1.Infrastructure.Menu
{
    class Exit : Option
    {
        private bool _executed;

        public Exit() : 
            base("Sortir.")
        {
            _executed = false;
        }

        public override void Execute()
        {
            _executed = true;
        }

        public bool Executed()
        {
            return _executed;
        }

        public void TitleLogOut()
        {
            this.title = "Tancar sessió.";
        }
    }
}
