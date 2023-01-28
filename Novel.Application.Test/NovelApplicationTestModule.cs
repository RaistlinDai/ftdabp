using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Novel.EntityFrameworkCore.Test;
using Novel.TestBase;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Novel.Application.Test;

[DependsOn(typeof(NovelApplicationModule))]
[DependsOn(typeof(NovelEntityFrameworkCoreTestModule))]
public class NovelApplicationTestModule : AbpModule
{
}