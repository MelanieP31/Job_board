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
