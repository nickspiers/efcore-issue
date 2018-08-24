# efcore-issue
1. Clone repository
2. Restore and build
3. Run migrations, which should add a WebApplication2_db database to your localdb instance
  - This database has 3 tables: Foo, Man and Chu.
  - Foo 1:1 Man 1:1 Chu, both optional.
  - Only Foo contains a row.
4. Run and it should start by requesting `api/Foos?$expand=man($expand=chu)`.
5. The response is an unfinished JSON object.
  - This message shows in the ASP.NET Core Web Server output tab - https://gist.github.com/nickspiers/3620840145d0a88e3966643613a5d442
  - If you have Just My Code disabled, you'll break on a null reference exception in EF Core.
