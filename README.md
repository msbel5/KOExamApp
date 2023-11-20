# KOExamApp

## Overview
KOExamApp is an interactive web application designed for creating and taking quizzes based on articles. It integrates educational content with quiz-making functionality, providing a unique platform for learning and assessment.

## Key Features
- **Quiz Creation:** Teachers can create quizzes based on articles fetched from Wired.com using an RSS feed. Quizzes can also be created based on custom articles.
- **Automatic Article Generation:** The application automatically fetches and creates articles from Wired.com, keeping the content fresh and relevant.
- **Interactive Exam Pages:** Exams are designed as single pages. After completing an exam, students can check their answers, and the application dynamically updates the page using jQuery to show correct and incorrect answers.
- **Rich Text Editing:** The application features a rich text editor for creating and editing articles and quizzes, allowing for a wide range of styles and fonts.
- **User Authentication:** Secure login and registration system for users to access personalized features.

## Technical Details
- **Controllers:** The application uses MVC architecture with controllers like `ArticlesController` and `ExamsController` for managing articles and exams.
- **Views:** Views like `Index.cshtml`, `Create.cshtml`, `Edit.cshtml`, `Details.cshtml`, and `Delete.cshtml` in the Exams section provide the user interface for quiz and exam management.
- **Scripts:** jQuery scripts are used for dynamic content loading and interactive features on exam pages.

## Usage
- **For Teachers:** Create quizzes based on automatically fetched articles or custom content. Manage quizzes through an intuitive interface.
- **For Students:** Participate in quizzes, get immediate feedback on answers, and engage with interactive learning material.

## Application URL
[Visit KOExamApp](http://koexamapp.msbel.com/)
