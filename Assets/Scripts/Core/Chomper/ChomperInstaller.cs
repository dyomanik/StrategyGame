using Zenject;

namespace Abstractions
{
    public class ChomperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackingDistance").FromInstance(5f);
            Container.Bind<int>().WithId("AttackingPeriod").FromInstance(1400);
        }
    }
}