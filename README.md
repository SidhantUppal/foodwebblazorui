---

# Food Ordering Web App

This web application allows users to browse and order food items listed by restaurants. Users can explore various cuisines, view restaurant menus, place orders, and track delivery status.

## Features

- **Browse Restaurants**: Explore a list of restaurants offering a variety of cuisines and dishes.
- **View Menus**: View restaurant menus with detailed descriptions, prices, and images of food items.
- **Place Orders**: Add items to the cart, specify delivery details, and place orders securely.
- **Order Tracking**: Track the status of orders in real-time, from preparation to delivery.
- **User Accounts**: Register and log in to create a personalized profile, save favorite restaurants, and view order history.

## Technologies Used

- **Frontend**: Blazor for building the frontend UI, Tailwind CSS for styling.
- **Backend**: ASP.NET Core for server-side logic and API endpoints.
- **Database**: Entity Framework Core for data access, used in memeory database.
- **Authentication**: ASP.NET Core Identity for user authentication and authorization.
- **API Documentation**: Swagger/OpenAPI for documenting and testing API endpoints.

## Getting Started

To run the Food Ordering web app locally, follow these steps:

1. **Clone the Repository**: `git clone https://github.com/SidhantUppal/foodwebblazorui.git`
3. **Set up the Project**:
   - Open the `backend` directory.
   - Install dependencies: `dotnet restore`
   - Run the backend server: `dotnet run`
4. **Set up the Frontend**:
   - Install dependencies for tailwind: `npm install  .... use can restore npm packeges if you are using visual studio`
   - Run the Fronend(Blazor): `dotnet run`
5. **Note**:
   - Set FoodieRider-B and FoodiRider.API as startup project. This project is using blazor as ui so you can run your custom backend or make backend copy as per you choice.
---
