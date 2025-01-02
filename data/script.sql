CREATE DATABASE IF NOT EXISTS `job_board`;
USE `job_board` ;

DROP TABLE IF EXISTS `experiences`;
DROP TABLE IF EXISTS `formations`;
DROP TABLE IF EXISTS `user_competencies`;
DROP TABLE IF EXISTS `competencies`;
DROP TABLE IF EXISTS `applications`;
DROP TABLE IF EXISTS `joboffer`;
DROP TABLE IF EXISTS `companies`;
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `admins`;


-- -------------------------------------
-- TABLE USERS
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` INT NOT NULL UNIQUE AUTO_INCREMENT,
  `first_name` VARCHAR(255),
  `last_name` VARCHAR(255),
  `email` VARCHAR(255) NOT NULL UNIQUE,
  `password` VARCHAR(255) NOT NULL,
  `phone` VARCHAR(10),
  `description` VARCHAR(255),
  `city` VARCHAR(255),
  `creation_date` DATETIME DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY  (`user_id`)

  -- One-To-Many (1 USER peut faire plusieurs APPLICATIONS)
  -- One-Yo-Many (1 USER peut avoir plusieurs formations)
  -- One-To-Many (1 USER peut avoir plusieur expériences) 
  -- Many-To-Many (plusieurs USERS peuvent avoir plusieurs COMPETENCES)
  
)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE COMPANIES 
-- --------------------------------------
CREATE TABLE IF NOT EXISTS `companies` (
  `company_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL UNIQUE,
  `description` TEXT,
  `location` VARCHAR(255), 
  `password` VARCHAR(255) NOT NULL,

  PRIMARY KEY  (`company_id`)

  -- One-To-Many : (Une COMPANIE peut créer plusieur JOBOFFER)
)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE JOBOFFER
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `joboffer` (
  `job_id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255),
  `short_description` VARCHAR(255),
  `long_description` TEXT,
  `contract_type` VARCHAR(255),
  `creation_date` DATETIME DEFAULT CURRENT_TIMESTAMP,
  `location` VARCHAR(100),
  
  `company_id` INT,
  
  PRIMARY KEY  (`job_id`),

  -- Many-To-One (Plusieurs JOBOFFER peuvent provenir d'une seule COMPANIE)
  CONSTRAINT `fk_company` FOREIGN KEY (`company_id`) REFERENCES `companies` (`company_id`) ON DELETE CASCADE

  -- One-To-Many (Une JobOffer peut avoir de multiple APPLICATIONS)
)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE APPLICATIONS
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `applications` (
  `app_id` INT NOT NULL AUTO_INCREMENT,
  `app_date` DATETIME DEFAULT CURRENT_TIMESTAMP,
  `message` VARCHAR(255),
  `status` ENUM('in progress', 'accepted', 'refused') DEFAULT 'in progress',

 -- Many-To-One (Plusieurs APPLICATION sur une JOBOFFER)
  `job_id` INT,
 -- Many-to-one : (Plusieurs APPLICATION peuvent être faite par un USER)
  `user_id` INT,

  PRIMARY KEY  (`app_id`),

  -- Les contrainte FK
  CONSTRAINT `fk_job` FOREIGN KEY (`job_id`) REFERENCES `joboffer` (`job_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE

)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE ADMINS
-- -------------------------------------
CREATE TABLE IF NOT EXISTS `admins` (
  `admin_id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(255) NOT NULL UNIQUE,
  `password` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`admin_id`)
);

-- -------------------------
-- TABLE COMPETENCIES
-- -----------------------------
CREATE TABLE IF NOT EXISTS `competencies` (
  `competency_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,

  PRIMARY KEY (`competency_id`)
)
AUTO_INCREMENT = 1;

-- TABLE DE LIAISON entre USER et COMPETENCES Many-To-Many

CREATE TABLE IF NOT EXISTS `user_competencies`(
  `user_id` INT NOT NULL,
  `competency_id`INT NOT NULL,

  PRIMARY KEY (`user_id`, `competency_id`),
  FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  FOREIGN KEY (`competency_id`) REFERENCES `competencies` (`competency_id`) ON DELETE CASCADE
);

-- -------------------------------------
-- TABLE FORMATIONS
-- -------------------------------------
CREATE TABLE IF NOT EXISTS `formations` (
    `formation_id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(255) NOT NULL,
    `institution` VARCHAR(255),
    `start_date` DATE,
    `end_date` DATE,
    `description` TEXT,
    
    `user_id` INT,
    PRIMARY KEY (`formation_id`),
	CONSTRAINT `fk_user_form` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
    
    -- Un user peut avoir plusieurs formations 
);

-- -------------------------------------
-- TABLE EXPERIENCES
-- -------------------------------------
CREATE TABLE IF NOT EXISTS `experiences` (
    `experience_id` INT NOT NULL AUTO_INCREMENT,
    `title` VARCHAR(255) NOT NULL,
    `company` VARCHAR(255),
    `start_date` DATE,
    `end_date` DATE,
    `description` VARCHAR(255),
    
    `user_id` INT,    
    PRIMARY KEY (`experience_id`),
    CONSTRAINT `fk_user_exp` foreign key (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
    
);

INSERT INTO `users` (first_name, last_name, email, password, phone, description, city) 
VALUES 
('John', 'Doe', 'john.doe@example.com', 'password123', '1234567890', 'Experienced software developer', 'New York'),
('Jane', 'Smith', 'jane.smith@example.com', 'securepass', '9876543210', 'Data analyst passionate about AI', 'San Francisco');

INSERT INTO `companies` (name, email, description, location, password) 
VALUES 
('TechCorp', 'contact@techcorp.com', 'Innovative technology solutions', 'Seattle', 'techcorp2023'),
('DataPro', 'hr@datapro.com', 'Data-driven consulting services', 'Boston', 'dataprosecure');

INSERT INTO `joboffer` (title, short_description, long_description, contract_type, location, company_id) 
VALUES 
('Software Engineer', 'Develop scalable software solutions', 'We are looking for a skilled software engineer to join our team.', 'Full-Time', 'Remote', 1),
('Data Scientist', 'Analyze complex data sets', 'Join our analytics team to uncover insights and drive decisions.', 'Part-Time', 'Boston', 2);

INSERT INTO `applications` (app_date, message, status, job_id, user_id) 
VALUES 
(NOW(), 'I am excited about this opportunity!', 'in progress', 1, 1),
(NOW(), 'Looking forward to contributing to your team.', 'in progress', 2, 2);

INSERT INTO `admins` (email, password) 
VALUES 
('admin1@jobboard.com', 'adminpass1'),
('admin2@jobboard.com', 'adminpass2');

INSERT INTO `competencies` (name) 
VALUES 
('JavaScript'),
('Python'),
('SQL'),
('Machine Learning'),
('Project Management');

INSERT INTO `user_competencies` (user_id, competency_id) 
VALUES 
(1, 1), -- John Doe knows JavaScript
(1, 2), -- John Doe knows Python
(2, 4), -- Jane Smith knows Machine Learning
(2, 5); -- Jane Smith knows Project Management

INSERT INTO `formations` (name, institution, start_date, end_date, description, user_id) 
VALUES 
('Computer Science BSc', 'MIT', '2015-09-01', '2019-06-30', 'Graduated with honors', 1),
('Data Science Bootcamp', 'General Assembly', '2021-01-01', '2021-06-30', 'Intensive program focused on machine learning', 2);

INSERT INTO `experiences` (title, company, start_date, end_date, description, user_id) 
VALUES 
('Software Developer', 'Tech Solutions Inc.', '2019-07-01', '2022-12-31', 'Developed web applications using modern frameworks', 1),
('Data Analyst', 'Data Insights LLC', '2022-01-01', '2023-12-31', 'Analyzed data and built predictive models', 2);


