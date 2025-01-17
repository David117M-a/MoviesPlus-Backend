# 🎬 MoviesPlus-Backend

A robust backend for managing and exploring a collection of movies. This project allows you to see all movies listed, filter them by title, genre, and actor, register new movies, and add cover photos to display in the movies list.

![Movies](https://i.giphy.com/media/v1.Y2lkPTc5MGI3NjExdWgzbnFyMGJ3bmFnbGZqOTZwcDYxc3I4Z3FpY21oMjY0aGt6M2xobyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/oe1kFNiUhLcSA/giphy.gif)

## 🌟 Functionalities

- **See All Movies Listed**: Display all movies available in the database.
- **Filter Movies**:
  - By Title
  - By Genre
  - By Actor
- **Register New Movies**: Add new movies to the collection.
- **Add Cover Photo**: Include a cover photo for each movie, either as an image link or a base64 image.

## 📦 Installation

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/David117M-a/MoviesPlus-Backend.git
    ```

2. **Open the Solution**:
    - Open the solution with the latest version of Visual Studio.

3. **Configure SQL Connection**:
    - Open the `appsettings.json` file and ensure the SQL connection string corresponds to your SQL server name:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=MoviesPlus;TrustServerCertificate=true;Encrypt=false;Integrated Security=SSPI;"
    }
    ```
    > Note: The project uses Windows authentication to access the database.

4. **Update the Database**:
    - Inside Visual Studio, open the "Package Manager Console" (Tools -> NuGet Package Manager -> Package Manager Console).
    - Execute the following command:
    ```bash
    Update-Database
    ```
    This will create the database on your SQL Server.

5. **Insert Initial Data**:
    - Open SQL Management Studio and execute the following SQL commands:
    ```sql
    USE MoviesPlus;
    GO
    INSERT INTO Genres ([Name]) VALUES ('Comedy');
    INSERT INTO Genres ([Name]) VALUES ('Horror');
    INSERT INTO Genres ([Name]) VALUES ('Fiction');
    INSERT INTO Genres ([Name]) VALUES ('Drama');
    INSERT INTO Genres ([Name]) VALUES ('Family');
    GO

    INSERT INTO Actors ([Name], Photo) VALUES ('Samuel L. Jackson', 'https://m.media-amazon.com/images/M/MV5BMTQ1NTQwMTYxNl5BMl5BanBnXkFtZTYwMjA1MzY1._V1_FMjpg_UX1000_.jpg');
    INSERT INTO Actors ([Name], Photo) VALUES ('Brad Pitt', 'https://phantom-telva.unidadeditorial.es/0b85f74f1f405db121aea83f87d43a72/resize/828/f/jpg/assets/multimedia/imagenes/2023/07/04/16884783365688.jpg');
    INSERT INTO Actors ([Name], Photo) VALUES ('Leonardo DiCaprio', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_DRZJM7YU86T5sFR_R0mMf6KOSs_wlfPMezdlH7nGocbKwRhs');
    INSERT INTO Actors ([Name], Photo) VALUES ('Tom Hanks', 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRhvG2pdEygKaC6fsp7fCHvulcfTMNdA2Q4Djv4j2JGElwOIyFb');
    INSERT INTO Actors ([Name], Photo) VALUES ('Morgan Freeman', 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSHry6OCzndUSh8B9zQLS_krK5jbidJs9tIwx0VQaKnZ8JZqya8');
    GO
    ```


6. **Run the Project**:
    - Get back to Visual Studio and run the project using HTTPS.


## 🤝 Contributing

Contributions are welcome! Please create an issue or a pull request for any features, bug fixes, or enhancements.

## 📜 License

This project is licensed under the MIT License. See the LICENSE file for details.

## 📞 Contact

For any inquiries, please contact [David117M-a](https://github.com/David117M-a).