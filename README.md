# Management-Platform-For-BnB
Custom Solution for Booking Accommodations &amp; Event Management for an Operational B&amp;B

This repository contains the source code for a Bed and Breakfast (B&amp;B) facility website, providing users with comprehensive information about the B&amp;B, as well as allowing them to book their holiday.
On the other hand, the owners can manage said bookings and create new events, such as including live music nights.
The comprehensive Admin Dashboard gives the owners the easy access they need to manage their business.

## Functionality

- **Information Hub:** The website serves as an information hub, providing details about the B&amp;B, amenities, local attractions, and more.
- **Booking System:** Customers can easily book their stay at the B&amp;B through the intuitive booking interface.
- **Admin Dashboard:** The admin dashboard allows owners to manage reservations and customer data, providing a calendar for easy overview. It enables one-click confirmations and cancellations of reservations.
- **Event Management:** Owners can efficiently manage events, such as live music nights, happening at the B&amp;B.
- **Automated Mailing System:** The mailing system sends emails to the customers upon request, confirmation or denial of a reservation.

## Technology Stack

- **.NET Framework:** The backend of the website is developed using .NET Core 8.0, providing robustness and performance.
- **Entity Framework Core:** ORM (Object-Relational Mapping) framework used for database interactions.
- **PostgreSQL:** The database management system used is PostgreSQL, ensuring data integrity and reliability.
- **Google Map API:** Integrated for map functionality, enhancing the contacts section of the website.
- **HTML, CSS, Bootstrap:** Frontend technologies utilized for designing and styling the user interface, ensuring responsiveness and aesthetics.
- **JavaScript:** Used to implement interactive features and enhance user experience.
- **Font Awesome:** Icon library used to add visually appealing icons throughout the website.
- **X.PagedList:** 3rd party NuGet package utilized for easier pagination, simplifying the management of large datasets and improving user navigation.
- **Docker Image:** The repository includes a Docker image for easy deployment, streamlining the setup process and making it hassle-free for users to get started.

## Deployment
## Deployment with Docker Compose

The website is easily deployable using Docker Compose, which allows you to define and run multi-container Docker applications. Follow these steps:

1. Install Docker Compose on your system if you haven't already.
2. Clone this repository to your local machine:
```
git clone https://github.com/OtakuDevs/Management-Platform-For-BnB.git
```
3. Navigate to the cloned repository directory:
```
cd SkeppsgardenBnB
```
4. Customize the environment variables in the provided `.env` file according to your requirements.
5. Run the Docker Compose command to build and start the containers:
```
docker-compose up -d
```
6. Access the website by navigating to `http://localhost:8080` in your web browser.

For more details on Docker Compose usage, refer to the [official documentation](https://docs.docker.com/compose/).

## Deployment with Separate Docker Containers

The website and PostgreSQL database can be deployed as separate Docker containers within the same network. Follow these steps:

1. Pull the Docker image for the website from the repository:
```
docker pull kaiserdmc/skeppsgardenbnb:0.9
```
2. Pull the Docker image for PostgreSQL:
```
docker pull postgres:16.2
```
3. Create a Docker network:
```
docker network create your-network-name
```
4. Run the PostgreSQL container within the network, specifying environment variables as needed:
```
docker run -d --network your-network-name --name skeppsgardenbnb_db -e POSTGRES_PASSWORD=postres-password postgres:16.2
```
5. Run the website container within the network, linking it to the PostgreSQL container and specifying environment variables as needed:
```
docker run -d --network your-network-name -p 8080:8080 --name skeppsgardenbnb 
-e DATABASE_HOST=skeppsgardenbnb_db -e DATABASE_NAME=skeppsgardenbnb_datavbase -e DATABASE_USER=postgres 
-e DATABASE_PASSWORD=postgres-password kaiserdmc/skeppsgardenbnb:0.9
```
6. Access the website by navigating to `http://localhost:8080` in your web browser.

For more details on Docker container management, refer to the [official documentation](https://docs.docker.com/engine/reference/run/).

### Get in Touch

Thank you for exploring our repository! 
We're committed to delivering high-quality solutions and are open to collaboration opportunities.

**Contact Information:**

For any questions, feedback, or inquiries, please feel free to contact us:

- **Email:** [contact@otakudevs.net](mailto:contact@otakudevs.net)

We welcome discussions about customization or development services related to similar projects. Get in touch, and let's explore how we can work together.

---

**Note:** This repository serves as a reference for our work and capabilities. If you're interested in discussing potential collaborations or have specific project requirements, we'd love to hear from you. Our team is here to assist you in bringing your ideas to fruition.
