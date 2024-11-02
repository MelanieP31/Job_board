CREATE DATABASE IF NOT EXISTS `job_board`;
USE `job_board` ;

-- -------------------------------------
-- Supprimer pour recréé, a supprimer plus tard juste pour tester
-- -------------------------------------
DROP TABLE IF EXISTS `applications`;
DROP TABLE IF EXISTS `joboffer`;
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `companies`;

-- -------------------------------------
-- TABLE COMPANIES 
-- --------------------------------------
CREATE TABLE IF NOT EXISTS `companies` (
  `company_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL UNIQUE,
  `description` VARCHAR(255),
  `location` VARCHAR(255), 
  `password` VARCHAR(255),
  `validated` BOOLEAN DEFAULT FALSE,

  PRIMARY KEY  (`company_id`)

  -- OneToMany : One Companies -> Many advertisement
)
AUTO_INCREMENT = 1;


-- -------------------------------------
-- TABLE USERS
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` INT NOT NULL UNIQUE AUTO_INCREMENT,
  `first_name` VARCHAR(255),
  `last_name` VARCHAR(255),
  `email` VARCHAR(255),
  `phone` VARCHAR(10),
  `description` VARCHAR(255),
  `password` VARCHAR(255),
  `city` VARCHAR(255),
  `user_type` VARCHAR(10) CHECK (`user_type` IN ('admin', 'company', 'user')),
  `creation_date` DATETIME,
  `cv_file` VARCHAR(255),

  -- OneToMany : One User -> Many application
  -- OneToOne : One user(company) -> One companie

  PRIMARY KEY  (`user_id`)

)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE JOBOFFER  (ad = advertisement)
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `joboffer` (
  `job_id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255),
  `short_description` VARCHAR(255),
  `long_description` LONGTEXT,
  `contract_type` VARCHAR(255),
  `creation_date` DATETIME,
  `location` VARCHAR(100),
  `company_id` INT,
  
  PRIMARY KEY  (`job_id`),

  -- Les contrainites des FK
  CONSTRAINT `fk_company` FOREIGN KEY (`company_id`) REFERENCES `companies` (`company_id`) ON DELETE CASCADE
)
AUTO_INCREMENT = 1;

-- -------------------------------------
-- TABLE APPLICATIONS
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `applications` (
  `app_id` INT NOT NULL AUTO_INCREMENT,
  `app_date` DATETIME,
  `message` VARCHAR(255),

 -- Many-to-one : Many application --> one advert
  `job_id` INT,
 -- Many-to-one : Many application --> One candidats
  `user_id` INT,

  PRIMARY KEY  (`app_id`),

  -- Les contrainte FK
  CONSTRAINT `fk_job` FOREIGN KEY (`job_id`) REFERENCES `joboffer` (`job_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE

)
AUTO_INCREMENT = 1;

-- Exemple (généré)
-- -------------------------------------
-- Insérer des exemples dans la table COMPANIES
-- -------------------------------------
INSERT INTO `companies` (`name`, `email`, `description`, `location`, `password`, `validated`)
VALUES 
    ('Tech Solutions', 'contact@techsolutions.com', 'Leader in IT consulting and development', 'Paris', 'password123', TRUE),
    ('Green Energy', 'hr@greenenergy.com', 'Renewable energy provider', 'Lyon', 'password456', FALSE),
    ('EduInnov', 'info@eduinnov.com', 'Innovative solutions for educational institutions', 'Marseille', 'password789', TRUE);

-- -------------------------------------
-- Insérer des exemples dans la table USERS
-- -----------joboffer--------------------------
INSERT INTO `users` (`first_name`, `last_name`, `email`, `phone`, `description`, `password`, `city`, `user_type`, `cv_file`)
VALUES 
    ('Alice', 'Martin', 'alice.martin@example.com', '0612345678', 'Experienced data scientist', 'alicepass', 'Paris', 'user', '/cv/alice_martin.pdf'),
    ('Bob', 'Dupont', 'bob.dupont@example.com', '0623456789', 'Senior software engineer', 'bobpass', 'Lyon', 'user', '/cv/bob_dupont.pdf'),
    ('Charlie', 'Durand', 'charlie.durand@example.com', '0634567890', 'HR manager at Green Energy', 'charliepass', 'Lyon', 'company', NULL),
    ('Admin', 'Admin', 'admin@example.com', NULL, 'System administrator', 'adminpass', 'Toulouse', 'admin', NULL);

-- -------------------------------------
-- Insérer des exemples dans la table JOBOFFER
-- -------------------------------------
INSERT INTO `joboffer` (`title`, `short_description`, `long_description`, `contract_type`, `location`, `company_id`)
VALUES 
    ('Data Analyst', 'Analyze data for business insights', 'Responsible for data analysis, reporting, and dashboard creation.', 'CDI', 'Paris', 1),
    ('Software Developer', 'Develop software solutions', 'Involved in all stages of software development life cycle.', 'CDD', 'Lyon', 2),
    ('Project Manager', 'Manage IT projects', 'Oversee and ensure the successful delivery of projects.', 'Freelance', 'Marseille', 1),
    ('Renewable Energy Engineer', 'Design renewable energy systems', 'Work on green energy projects.', 'CDI', 'Lyon', 2);

-- -------------------------------------
-- Insérer des exemples dans la table APPLICATIONS
-- -------------------------------------
INSERT INTO `applications` (`app_date`, `message`, `job_id`, `user_id`)
VALUES 
    (NOW(), 'I am very interested in this position.', 1, 1),
    (NOW(), 'I believe my skills are a perfect fit for this job.', 2, 2),
    (NOW(), 'Looking forward to contributing to your team.', 3, 1),
    (NOW(), 'I have experience in renewable energy and would like to apply.', 4, 2);


