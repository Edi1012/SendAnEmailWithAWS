# Email Sending Program

## Overview
This C# console application leverages the AWS SDK to interact with Amazon Simple Email Service (SES) for email delivery. It offers a straightforward interface for selecting and sending emails based on HTML templates. Key functionality includes:


- Configuration of AWS credentials and default email addresses.
- A user-friendly console menu for template selection.
- Sending emails based on chosen templates or all templates in a specified directory.
- Placeholder replacement in HTML templates with dynamic content.
- Robust error handling for reliable email delivery.
- To utilize this program, set up your AWS credentials and default email addresses, and place your HTML email templates in the designated folder. Run the application to dispatch customized emails.


## Prerequisites
Before using this program, ensure you have the following:

- **AWS Access Key and Secret Key**: You need valid AWS access and secret keys with permissions to use SES.
- **Default Sender and Recipient Email Addresses**: Default email addresses for the sender and recipient.
- **HTML Template Files**: Prepare HTML template files containing placeholders for dynamic content.

## Setup
1. Clone or download this repository to your local machine.
2. Open the program in your preferred C# development environment.

## Configuration
Edit the following variables in the code to configure the program:

```csharp
string AWSaccesskey = "AAAA"; // Replace with your AWS access key.
string AWSsecretkey = "AAAA"; // Replace with your AWS secret key.
string defaultSenderAddress = "sender@example.com"; // Set the default sender's email address.
string defaultRecipientAddress = "recipient@example.com"; // Set the default recipient's email address.
string templatesFolderPath = "C:\\your\\template\\folder"; // Path to the folder containing HTML templates.
```

## Usage
1. After configuring the program, run it.
2. The program will prompt you to enter the template number or 'all' to send all templates.
3. If you choose a specific template or 'all', the program will load the HTML template file(s).
4. Customize the template(s) by replacing placeholders within them. In the provided code, it replaces {Usuario|nombre} with "Edi" as an example.
5. The program will send the email(s) to the default recipient address or the one you specify during runtime.

## Important Notes
- Make sure you have set up Amazon SES properly with the necessary permissions.
- Be cautious with your AWS access and secret keys; do not expose them in public repositories.

## Author
Edi

## Final Notes
- This program utilizes Amazon SES for email sending.
- The HTML template can be customized to include any desired content.
