using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;
using Volo.Abp.Uow;

namespace Novel.TestBase;

/// <summary>
/// All test classes are derived from this base test class
/// </summary>
/// <typeparam name="TStartupModule"></typeparam>
public abstract class NovelTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
    where TStartupModule : IAbpModule
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }

    protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
            using (var uow = uowManager.Begin(options))
            {
                await action();
                await uow.CompleteAsync();
            }
        }
    }

    protected virtual async Task<TResult> WithUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options, Func<Task<TResult>> action)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
            using (var uow = uowManager.Begin(options))
            {
                var result = await action();
                await uow.CompleteAsync();
                return result;
            }
        }
    }

    protected virtual Task WithUnitOfWorkAsync(Func<Task> action)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), action);
    }
    
    protected virtual Task<TResult> WithUnitOfWorkAsync<TResult>(Func<Task<TResult>> action)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), action);
    }
}