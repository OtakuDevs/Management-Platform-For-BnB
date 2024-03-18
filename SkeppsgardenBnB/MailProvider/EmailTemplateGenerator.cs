using System.Text;

namespace MailProvider;

public class EmailTemplateGenerator
{
    // TODO: Do not forget to change the name in the templated before deployment
    public static string GenerateReservationRequestConfirmationEmail(string customerName, string requestNumber)
    {
        StringBuilder template = new StringBuilder();

        template.AppendLine("<!DOCTYPE html>");
        template.AppendLine("<html lang=\"en\">");
        template.AppendLine("<head>");
        template.AppendLine("    <meta charset=\"UTF-8\">");
        template.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        template.AppendLine($"    <title>Reservation Request Confirmation</title>");
        template.AppendLine("    <style>");
        // Add your CSS styles here
        template.AppendLine("    </style>");
        template.AppendLine("</head>");
        template.AppendLine("<body>");
        template.AppendLine("    <div class=\"container\">");
        template.AppendLine("        <div class=\"header\">");
        template.AppendLine($"            <h2>REQ#{requestNumber} Reservation Request Received</h2>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"content\">");
        template.AppendLine($"            <p>Dear {customerName},</p>");
        template.AppendLine(
            $"            <p>We have received your reservation request with reference number REQ#{requestNumber}. Our team is currently reviewing your request, and we will get back to you shortly.</p>");
        template.AppendLine(
            "<p>If you have any urgent inquiries or need immediate assistance, please contact us at contact@skeppsgardenbb.se</p>");
        template.AppendLine("<p>Best regards, <br> SkeppsgårdenBnB Staff</p>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"footer\">");
        template.AppendLine("            <p>This is an automated email. Please do not reply to this email.</p>");
        template.AppendLine("        </div>");
        template.AppendLine("    </div>");
        template.AppendLine("</body>");
        template.AppendLine("</html>");

        return template.ToString();
    }

    public static string GenerateReservationRequestConfirmationEmailMoreNights(string customerName,
        string requestNumber)
    {
        StringBuilder template = new StringBuilder();

        template.AppendLine("<!DOCTYPE html>");
        template.AppendLine("<html lang=\"en\">");
        template.AppendLine("<head>");
        template.AppendLine("    <meta charset=\"UTF-8\">");
        template.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        template.AppendLine($"    <title>Reservation Request Confirmation</title>");
        template.AppendLine("    <style>");
        // Add your CSS styles here
        template.AppendLine("    </style>");
        template.AppendLine("</head>");
        template.AppendLine("<body>");
        template.AppendLine("    <div class=\"container\">");
        template.AppendLine("        <div class=\"header\">");
        template.AppendLine($"            <h2>REQ#{requestNumber} Reservation Request Received</h2>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"content\">");
        template.AppendLine($"            <p>Dear {customerName},</p>");
        template.AppendLine(
            $"            <p>We have received your reservation request with reference number REQ#{requestNumber}. Our team is currently reviewing your request, and we will get back to you shortly.</p>");
        template.AppendLine(
            $"            <p>Since you requested a stay for more than 3 nights you are eligible for additional discount. In case the discount is applied, our staff will confirm your request and you will receive an email confirming your new pricing.</p>");
        template.AppendLine(
            "<p>If you have any urgent inquiries or need immediate assistance, please contact us at contact@skeppsgardenbb.se</p>");
        template.AppendLine("<p>Best regards, <br> SkeppsgårdenBnB Staff</p>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"footer\">");
        template.AppendLine("            <p>This is an automated email. Please do not reply to this email.</p>");
        template.AppendLine("        </div>");
        template.AppendLine("    </div>");
        template.AppendLine("</body>");
        template.AppendLine("</html>");

        return template.ToString();
    }

    public static string GenerateReservationConfirmationEmail(string customerName, string requestNumber, string checkIn,
        string checkOut, string numberOfPeople, string totalPrice, string ownerNotes)
    {
        StringBuilder template = new StringBuilder();

        template.AppendLine("<!DOCTYPE html>");
        template.AppendLine("<html lang=\"en\">");
        template.AppendLine("<head>");
        template.AppendLine("    <meta charset=\"UTF-8\">");
        template.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        template.AppendLine($"    <title>Reservation Confirmation</title>");
        template.AppendLine("    <style>");
        template.AppendLine("    </style>");
        template.AppendLine("</head>");
        template.AppendLine("<body>");
        template.AppendLine("    <div class=\"container\">");
        template.AppendLine("        <div class=\"header\">");
        template.AppendLine($"            <h2>RES#{requestNumber} Reservation Confirmed</h2>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"content\">");
        template.AppendLine($"            <p>Dear {customerName},</p>");
        template.AppendLine(
            $"            <p>We have received your reservation request RES#{requestNumber} for {numberOfPeople} person/s on the following dates: {checkIn} - {checkOut}.</p>");
        template.AppendLine("            <p><strong>Reservation Details:</strong></p>");
        template.AppendLine("            <ul>");
        template.AppendLine($"                <li><strong>Reservation number:</strong> RES#{requestNumber}</li>");
        template.AppendLine($"                <li><strong>Dates:</strong> {checkIn} - {checkOut}</li>");
        template.AppendLine("            </ul>");
        template.AppendLine($"             <p>Your final price is: {totalPrice}.</p>");
        template.AppendLine($"             <p>Notes from our staff: {ownerNotes}.</p>");
        template.AppendLine(
            "             <p>Thank you for choosing SkeppsgårdenBnB for your stay! We look forward to hosting you.</p>");
        template.AppendLine(
            "<p> If you have any further questions or need assistance,please feel free to contact us at contact@skeppsgardenbb.se</p>");
        template.AppendLine("<p> Best regards, <br> SkeppsgårdenBnB Staff </p>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"footer\">");
        template.AppendLine("            <p>This is an automated email. Please do not reply to this email.</p>");
        template.AppendLine("        </div>");
        template.AppendLine("    </div>");
        template.AppendLine("</body>");
        template.AppendLine("</html>");

        return template.ToString();
    }

    public static string GenerateReservationDenialEmail(string customerName, string requestNumber, string denialReason,
        string ownerNotes)
    {
        StringBuilder template = new StringBuilder();

        template.AppendLine("<!DOCTYPE html>");
        template.AppendLine("<html lang=\"en\">");
        template.AppendLine("<head>");
        template.AppendLine("    <meta charset=\"UTF-8\">");
        template.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        template.AppendLine($"    <title>Reservation Denial</title>");
        template.AppendLine("    <style>");
        // Add your CSS styles here
        template.AppendLine("    </style>");
        template.AppendLine("</head>");
        template.AppendLine("<body>");
        template.AppendLine("    <div class=\"container\">");
        template.AppendLine("        <div class=\"header\">");
        template.AppendLine($"            <h2>RES#{requestNumber} Reservation Denied</h2>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"content\">");
        template.AppendLine($"            <p>Dear {customerName},</p>");
        template.AppendLine(
            $"            <p>We regret to inform you that your reservation request RES#{requestNumber} has been denied.</p>");
        template.AppendLine("            <p><strong>Denial Reason:</strong></p>");
        template.AppendLine($"            <p>{denialReason}</p>");
        template.AppendLine($"             <p>Notes from our staff: {ownerNotes}.</p>");
        template.AppendLine(
            "<p>If you have any questions or concerns, please feel free to contact us at contact@skeppsgardenbb.se</p>");
        template.AppendLine("<p>Best regards, <br> SkeppsgårdenBnB Staff</p>");
        template.AppendLine("        </div>");
        template.AppendLine("        <div class=\"footer\">");
        template.AppendLine("            <p>This is an automated email. Please do not reply to this email.</p>");
        template.AppendLine("        </div>");
        template.AppendLine("    </div>");
        template.AppendLine("</body>");
        template.AppendLine("</html>");

        return template.ToString();
    }
}