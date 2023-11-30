# Email Sending Program

## Overview
This program is designed to send emails using Amazon Simple Email Service (SES) and a provided HTML template. It allows you to customize the email's content, recipient, sender, and subject before sending. This README provides instructions on setting up and using the program.

## Prerequisites
Before using this program, ensure you have the following:

- **AWS Access Key and Secret Key**: You need valid AWS access and secret keys with permissions to use SES.
- **Default Sender and Recipient Email Addresses**: Default email addresses for the sender and recipient.
- **HTML Template File**: An HTML template file with placeholders for dynamic content.

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
string templateFilePath = "..\\document.html"; // Provide the path to your HTML template file.
```

## Usage
1. After configuring the program, run it.
2. The program will prompt you to enter the email subject.
3. The HTML template file will be loaded, and you can customize it by replacing placeholders. In the provided code, it replaces `{Usuario|nombre}` with `"Edi"` as an example.
4. The program will send the email to the default recipient address or the one you specify during runtime.

## Important Notes
- Make sure you have set up Amazon SES properly with the necessary permissions.
- Be cautious with your AWS access and secret keys; do not expose them in public repositories.

## Author
Edi

## Final Notes
- This program utilizes Amazon SES for email sending.
- The HTML template can be customized to include any desired content.
