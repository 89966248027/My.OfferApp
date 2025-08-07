using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My.OfferApp.Dal.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddFakeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
INSERT INTO
  [dict].[Supplier] ([Name], [CreatedDate])
VALUES
  (
    'ООО Поставка 1',
    '2025-06-11T12:09:47.1740431'
  ),
  (
    'АО Снабжение 2',
    '2025-07-08T12:09:47.1740431'
  ),
  ('ИП Иванов 3', '2025-07-11T12:09:47.1740431'),
  (
    'ЗАО Логистика 4',
    '2025-08-01T12:09:47.1740431'
  ),
  ('Поставщик 5', '2025-08-06T12:09:47.1740431');
"
            );

            migrationBuilder.Sql(
                @"
INSERT INTO
  [common].[Offer] (
    [Mark],
    [Model],
    [SupplierId],
    [RegistrationDate]
  )
VALUES
  (
    'Toyota',
    'Camry',
    1,
    '2025-06-01T12:09:47.1740431'
  ),
  (
    'Hyundai',
    'Solaris',
    2,
    '2025-06-12T12:09:47.1740431'
  ),
  ('Kia', 'Rio', 3, '2025-07-08T12:09:47.1740431'),
  (
    'Volkswagen',
    'Polo',
    4,
    '2025-07-09T12:09:47.1740431'
  ),
  (
    'Renault',
    'Logan',
    5,
    '2025-07-15T12:09:47.1740431'
  ),
  ('Ford', 'Focus', 1, '2025-07-15T16:09:47.1740431'),
  (
    'Chevrolet',
    'Cruze',
    2,
    '2025-07-22T12:09:47.1740431'
  ),
  (
    'Skoda',
    'Octavia',
    3,
    '2025-07-25T12:09:47.1740431'
  ),
  (
    'Nissan',
    'Almera',
    4,
    '2025-07-25T13:09:47.1740431'
  ),
  ('Mazda', '3', 5, '2025-07-25T18:09:47.1740431'),
  (
    'Lada',
    'Vesta',
    1,
    '2025-08-01T12:09:47.1740431'
  ),
  (
    'Lada',
    'Granta',
    2,
    '2025-08-03T10:09:47.1740431'
  ),
  (
    'Geely',
    'Coolray',
    3,
    '2025-08-03T12:09:47.1740431'
  ),
  (
    'Chery',
    'Tiggo 4',
    4,
    '2025-08-06T12:09:47.1740431'
  ),
  (
    'Haval',
    'Jolion',
    5,
    '2025-08-07T15:09:47.1740431'
  );
"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [common].[Offer]");

            migrationBuilder.Sql("DELETE FROM [dict].[Supplier]");
        }
    }
}
