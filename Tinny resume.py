from fpdf import FPDF

class CustomPDF(FPDF):
    def header(self):
        # Add Name as header
        self.set_font('Arial', 'B', 16)
        self.cell(0, 10, 'Tinny Mosimanyana', ln=True, align='C')
        self.set_font('Arial', '', 10)
        self.cell(0, 5, 'Kweneng District, Botswana | Email: mbothepha@gmail.com | LinkedIn: linkedin.com/in/tinny29', ln=True, align='C')
        self.ln(10)

    def section_title(self, title):
        self.set_font('Arial', 'B', 12)
        self.set_text_color(0, 0, 128)
        self.cell(0, 10, title, ln=True)
        self.set_text_color(0, 0, 0)

    def section_body(self, body):
        self.set_font('Arial', '', 10)
        self.multi_cell(0, 8, body)
        self.ln(2)

# Initialize PDF
pdf = CustomPDF()
pdf.add_page()

# Profile Summary
pdf.section_title("Profile Summary")
profile_summary = (
    "Motivated and adaptable freelance web developer and IT support specialist with expertise in "
    "HTML, CSS, JavaScript, and Python. Proven ability to develop responsive websites and deliver "
    "innovative software solutions. Committed to professional growth, collaboration, and creating user-focused applications."
)
pdf.section_body(profile_summary)

# Technical Skills
pdf.section_title("Technical Skills")
technical_skills = (
    "- Programming Languages: HTML, CSS, JavaScript, Python\n"
    "- Frameworks & Libraries: React, Bootstrap, Flask\n"
    "- Tools: Git, VS Code, Figma\n"
    "- Other Skills: Responsive Design, Basic Database Management, Debugging, IT Support"
)
pdf.section_body(technical_skills)

# Experience
pdf.section_title("Experience")
experience = (
    "Freelance Web Developer | Self-Employed | Sep 2024 - Present\n"
    "- Designed and developed responsive websites for small businesses using HTML, CSS, JavaScript, and Python.\n"
    "- Provided IT support and resolved technical issues, maintaining a client satisfaction rate of 95%.\n\n"
    "Sales Representative & Administrative Clerk | JAKALIN Investments | Jan 2021 - Sep 2024\n"
    "- Managed customer inquiries and streamlined administrative processes, improving efficiency by 15%.\n"
    "- Coordinated sales strategies, resulting in a 10% increase in quarterly sales.\n\n"
    "Teacher | Kopong CJSS | May 2019 - May 2021\n"
    "- Developed and delivered engaging lessons, leading to a 20% improvement in student performance."
)
pdf.section_body(experience)

# Projects
pdf.section_title("Projects")
projects = (
    "- Personal Portfolio Website:\n"
    "  Built a responsive portfolio showcasing web development projects, improving client engagement by 30%.\n"
    "- E-Commerce Mockup:\n"
    "  Developed a Python-based e-commerce platform with database integration, simulating real-world e-commerce scenarios."
)
pdf.section_body(projects)

# Education
pdf.section_title("Education")
education = (
    "- Brigham Young University - Idaho\n"
    "  BASc in Software Development (Expected Apr 2025)\n"
    "- Alison\n"
    "  Diploma in Educational Psychology (Jun 2021)\n"
    "- Institute of Entrepreneurship Development\n"
    "  Certificate in Entrepreneurship (Mar 2021)\n"
    "- Kgari Sechele Senior School\n"
    "  BGCSE in Business/Commerce (2009)"
)
pdf.section_body(education)

# Save the updated PDF
file_path_updated = "/mnt/data/Tinny_Mosimanyana_Updated_Resume.pdf"
pdf.output(file_path_updated)

file_path_updated
