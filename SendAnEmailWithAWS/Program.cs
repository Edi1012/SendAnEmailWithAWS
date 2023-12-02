using Amazon.SimpleEmail;
using SESActions;
using System.Text;
class Program
{
    // Separator bar for console output
    private static readonly string sepBar = new string('-', 80);

    static async Task Main(string[] args)
    {
        // Configure AWS credentials and other default settings
        string AWSaccesskey = "XXXXX"; // Your AWS access key
        string AWSsecretkey = "XXXXX"; // Your AWS secret key
        string defaultSenderAddress = "edi@gmail.com"; // Default sender email
        string defaultRecipientAddress = "ed@hotmail.com"; // Default recipient email
        string templatesFolderPath = "C:\\Users\\...\\Documents\\...\\Working\\Plantillas"; // Path to the templates folder

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

            // List of template HTML file names in the folder
            var templateFiles = Directory.GetFiles(templatesFolderPath, "*.html");

            if (templateFiles.Length == 0)
            {
                Console.WriteLine("No HTML templates found in the specified folder.");
                return;
            }

            // Display the list of available templates
            Console.WriteLine("Available templates:");
            for (int i = 0; i < templateFiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Path.GetFileName(templateFiles[i])}");
            }

            // Prompt the user to choose a template or send all templates
            Console.WriteLine("Enter the template number to use (or 'all' to send all templates):");
            var input = Console.ReadLine();

            if (input.ToLower() == "all")
            {
                // Send all emails based on all templates
                foreach (var templateFilePath in templateFiles)
                {
                    await SendEmailUsingTemplate(sesWrapper, senderAddress, toAddresses, templateFilePath);
                }
            }
            else if (int.TryParse(input, out int selectedTemplateIndex) && selectedTemplateIndex >= 1 && selectedTemplateIndex <= templateFiles.Length)
            {
                // Send the email based on the selected template
                var selectedTemplateFilePath = templateFiles[selectedTemplateIndex - 1];
                await SendEmailUsingTemplate(sesWrapper, senderAddress, toAddresses, selectedTemplateFilePath);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("All emails sent.");
            Console.WriteLine(sepBar);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending the emails: " + ex.Message);
        }
    }

    static async Task SendEmailUsingTemplate(SESWrapper sesWrapper, string senderAddress, List<string> toAddresses, string templateFilePath)
    {
        try
        {
            // Read the HTML template content from the file with UTF-8 encoding
            using (var streamReader = new StreamReader(templateFilePath, Encoding.UTF8))
            {
                var subject = Path.GetFileNameWithoutExtension(templateFilePath); // Get the file name without extension

                // Read the HTML template content from the file
                string bodyHtmlTemplate = File.ReadAllText(templateFilePath);

                // Replace placeholders in the template with dynamic content
                bodyHtmlTemplate = bodyHtmlTemplate.Replace("{Usuario|nombre}", "Edi"); // Example of placeholder replacement

                // Send the email using SES and get the message ID
                var messageId = await sesWrapper.SendEmailAsync(toAddresses, null, null, bodyHtmlTemplate, string.Empty, subject, senderAddress);

                Console.WriteLine($"Message {messageId} sent for template: {Path.GetFileName(templateFilePath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email for template {Path.GetFileName(templateFilePath)}: {ex.Message}");
        }
    }
}

