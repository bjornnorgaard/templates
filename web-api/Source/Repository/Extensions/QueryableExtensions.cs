// using System;
// using System.Linq;
// using System.Reflection;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
// using Microsoft.EntityFrameworkCore.Query;
// using Microsoft.EntityFrameworkCore.Query.Internal;
//
// namespace Repository.Extensions
// {
//     public static class QueryableExtensions
//     {
//         public static IQueryable<TEntity> Between<TEntity>(this IQueryable<TEntity> source,
//                                                            long from,
//                                                            long to) where TEntity : class
//         {
//             var fromDate = DateTimeOffset.FromUnixTimeMilliseconds(from).UtcDateTime
//                                          .ToString("yyyy/MM/dd HH:mm");
//             var toDate = DateTimeOffset.FromUnixTimeMilliseconds(to).UtcDateTime
//                                        .ToString("yyyy/MM/dd HH:mm");
//
//             var tableName = source.GetDbContext().Model.FindEntityType(typeof(TEntity))
//                                   .GetTableName();
//
//             var query =
//                 $"SELECT * FROM [dbo].[{tableName}] FOR SYSTEM_TIME BETWEEN '{fromDate}' AND '{toDate}' ";
//
//             return source.FromSql(query, tableName);
//         }
//
//         public static IQueryable<TEntity> Between<TEntity>(this IQueryable<TEntity> source,
//                                                            DateTime from,
//                                                            DateTime to) where TEntity : class
//         {
//             var tableName = source.GetDbContext().Model.FindEntityType(typeof(TEntity))
//                                   .GetTableName();
//
//             var query = $"SELECT * FROM [dbo].[{tableName}] " +
//                         $"FOR SYSTEM_TIME BETWEEN '{from:yyyy/MM/dd HH:mm}' AND '{to:yyyy/MM/dd HH:mm}' ";
//
//             return source.FromSql(query);
//         }
//
//         private static DbContext GetDbContext(this IQueryable query)
//         {
//             var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
//             var queryCompiler = typeof(EntityQueryProvider)
//                                 .GetField("_queryCompiler", bindingFlags)
//                                 ?.GetValue(query.Provider);
//
//             if (queryCompiler != null)
//             {
//                 var queryContextFactory = queryCompiler
//                                           .GetType().GetField("_queryContextFactory", bindingFlags)
//                                           ?.GetValue(queryCompiler);
//
//                 var dependencies = typeof(RelationalQueryContextFactory)
//                                    .GetProperty("Dependencies", bindingFlags)
//                                    ?.GetValue(queryContextFactory);
//
//                 var queryContextDependencies =
//                     typeof(DbContext).Assembly.GetType(typeof(QueryContextDependencies).FullName ??
//                                                        throw new Exception());
//
//                 var stateManagerProperty = queryContextDependencies
//                                            .GetProperty("StateManager",
//                                                         bindingFlags | BindingFlags.Public)
//                                            ?.GetValue(dependencies);
//
//                 var stateManager = (IStateManager) stateManagerProperty;
//
//                 stateManager ??= ((dynamic) stateManagerProperty)?.Value;
//
//                 return stateManager.Context;
//             }
//         }
//     }
// }
