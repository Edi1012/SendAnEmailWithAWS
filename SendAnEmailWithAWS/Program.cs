using Amazon.SimpleEmail;
using SESActions;

class Program
{
    private static readonly string sepBar = new string('-', 80);

    static async Task Main(string[] args)
    {
        string AWSaccesskey = "AAAA"; // Your AWS access key
        string AWSsecretkey = "AAAA"; // Your AWS secret key

        string defaultSenderAddress = "edi@gmail.com"; // Default sender email
        string defaultRecipientAddress = "edgar@gmail.com"; // Default recipient email

        string templateFilePath = "..\\document.html"; // Path to the HTML template file


        try
        {
            // Configure the AWS SES client
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(AWSaccesskey, AWSsecretkey);
            var sesClient = new AmazonSimpleEmailServiceClient(awsCredentials);

            // Configure the sesWrapper object
            var sesWrapper = new SESWrapper(sesClient);

            Console.WriteLine(sepBar);
            Console.WriteLine("Send an email.");

            var senderAddress = defaultSenderAddress;


            List<string> toAddresses = new List<string> { defaultRecipientAddress };

            // Rest of the code to send the email
            Console.WriteLine("Enter email subject:");
            var subject = Console.ReadLine();

            // Read the HTML template content from a file
            string bodyHtmlTemplate = File.ReadAllText(templateFilePath);

            // Replace placeholders in the template with dynamic content
            bodyHtmlTemplate = bodyHtmlTemplate.Replace("{Usuario|nombre}", "Edi"); // Metadato

            var messageId = await sesWrapper.SendEmailAsync(toAddresses, null, null, bodyHtmlTemplate, string.Empty, subject, senderAddress);

            Console.WriteLine($"Message {messageId} sent.");
            Console.WriteLine(sepBar);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending the email: " + ex.Message);
        }
    }
}
