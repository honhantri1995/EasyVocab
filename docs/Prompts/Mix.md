# Introduce the requirement
1. First of all, I want to introduce the requirement for my application to you. You must read `docs\ApplicationRequirement.md` carefully and slowly to grash all details about the requirement. Then tell me what do you understand about it? 

2. I think my requirement document has some English grammar mistakes, can you help me fix them?

3. Is my requirement document well-structured and easy to understand? If there are parts that you want to improve, please improve them. If there is any sentence is not clear, not concise, or too vague, please fix it.

4. Let's deep into the business of my app. Do you have any suggestion to make the app more useful, more user-friendly? Do you think which parts of the app are useless and not worthy to made?

# Generate the codebase structure
1. 
Based on the requirement `docs\ApplicationRequirement.md`, generate for me a folder and file structure for the app. You can leave files empty. I just want to have a code structure first.
The code structure must be:
  - Put inside the `src` folder.
  - Cross platforms: In the first version of the app, I will make it with Electron for Windows. But in later version, I might expand it to mobile with React Native and Exp. So the initial codebase must prepare for this future.
  - Well-organized and Standadized: This means following an excellent structure template which is used widely in well-known open source projects.
  - Easy to maintain: Changing one part does not cause side effect to other parts. Adding new parts is much easier without having to modify existing parts.
  - Model-View-Controller: The front end logics and back end logics must be completely separated. The database must be also separated from the code logics. **This point is very important to me, you must put biggest effort on this**.

# Generate the database
1. 
Based on the requirement `docs\ApplicationRequirement.md`, I want you to generate the database structure for my app in form of a Entity Relationship Diagram (ERD). The database structure must:
  - Work well with Firebase for data sync across devices.
  - Well-organized
  - Easy to maintain
  - Excellent performed

# Generate detailed design
1. Based on the requirement `docs\ApplicationRequirement.md` and the database `FIXME`, I want you to generate some plantuml diagrams as design document:
  - A system architecture diagram: Show high-level components (frontend, backend, database, external services)
  - A component diagram: Display modules, services, dependencies and their relationships
  - A class diagram: Show relationships between classes, inheritance, and composition
  - Some sequence diagrams: Show interaction between different components over time. Excellent for API calls, database operations, and async operations.

# Generate the UI code
1. Introduce the wireframe
Let's talk about the UI design for the app. I already draw many wireframes for the app in `FIXME`. You must read them carefully and tell me what do you understand about each wireframe? Can you list all UI components in a hierachy order.

2. Theme
You already understood the app wireframes.
Now let's dig deeper into the UI theme. **I already give you my requirements about UI design in `UI` session of `docs\ApplicationRequirement`**. Please follow them.

Now, based on the wireframe we analyzed before, generate a `ViewSpecification.md` in which you describe < -- FIXME -- >

3. UI Component template
Based on the `ViewSpecification.md`, generate HTML+CSS code for each UI component. Create directory for different themes, and put UI components in each directory.

4. Sidebar Navigation and the Home screen
Because my app contains lots of screens, it's hard for you and me to make them in once. So let's make each screen independently.
First, generate UI code for the Sidebar Navigation and the Home screen. You must follow UI Component Template in `FIXME`.

NOTE: The backend logic is temporarly skipped for now. You can hardcode some stub data for displaying or testing.

# Generate JS code
1.
Based on the `docs\ApplicationRequirement.md`, coding rule `docs\CodingRule.md`, database `FIXME` and design `FIXME`, FIXME

<!-- JS code for UI must be separated from JS code for backend business logics -->
<!-- In later version of the app, I can change the UI completely to make the app fresh (just like other famous software usually does). In this case, I want as less side effect to the backend business logics as much as possible) -->