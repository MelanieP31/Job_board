CREATE DATABASE IF NOT EXISTS `job_board`;
USE `job_board` ;

-- -------------------------------------
-- Supprimer pour recréé, a supprimer plus tard juste pour tester
-- -------------------------------------
DROP TABLE IF EXISTS `application`;
DROP TABLE IF EXISTS `advertisements`;
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `companies`;

-- -------------------------------------
-- TABLE COMPANIES  (cmp = companies)
-- --------------------------------------
CREATE TABLE IF NOT EXISTS `companies` (
  `cmp_id` INT NOT NULL auto_increment,
  `name` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL UNIQUE,
  `description` VARCHAR(255),
  `location` VARCHAR(255), 

  PRIMARY KEY  (`cmp_id`)

  -- OneToMany : One Companies -> Many advertisement
)
auto_increment =1;


-- -------------------------------------
-- TABLE USERS
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` INT NOT NULL UNIQUE auto_increment,
  `first_name` VARCHAR(255),
  `last_name` VARCHAR(255),
  `email` VARCHAR(255),
  `phone` VARCHAR(10),
  `description` VARCHAR(255),
  `password` VARCHAR(255),

  -- OneToMany : One User -> Many application

  PRIMARY KEY  (`user_id`)

)
auto_increment =1;

-- -------------------------------------
-- TABLE ADVERTISMENTS  (ad = advertisement)
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `advertisements` (
  `ad_id` INT NOT NULL auto_increment,
  `title` VARCHAR(255),
  `short_description` VARCHAR(255),
  `long_description` VARCHAR(255),
  `contract_type` VARCHAR(255),
  `salary` INT,
  `creation_date` DATETIME,

  `cmp_id` INT,
  PRIMARY KEY  (`ad_id`),

  -- Les contrainites des FK
  CONSTRAINT `fk_cmp` FOREIGN KEY (`cmp_id`) REFERENCES `companies` (`cmp_id`) ON DELETE CASCADE
)
auto_increment =1;

-- -------------------------------------
-- TABLE ADMIN
-- --------------------------------------

CREATE TABLE IF NOT EXISTS `application` (
  `application_id` INT NOT NULL auto_increment,
  `application_date` DATETIME,
  `message` VARCHAR(255),

 -- Many-to-one : Many application --> one advert
  `ad_id` INT,
 -- Many-to-one : Many application --> One candidats
  `user_id` INT,

  PRIMARY KEY  (`application_id`),

  -- Les contrainte FK
  CONSTRAINT `fk_ad` FOREIGN KEY (`ad_id`) REFERENCES `advertisements` (`ad_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE

)
auto_increment =1;


-- Gestion des suppression : qd une ligne supprimer dans les table One ex: une annonce supprimer
-- alors il faut supprimer les candidature : ON DELETE CASCADE
-- sinon ON DELETE NULL (pas trop compris a part 'au cas où ... )

-- Insérer dans la table COMPANIES
INSERT INTO `companies` (`name`, `email`, `description`, `location`) VALUES 
('Tech Corp', 'contact@techcorp.com', 'A leading tech company', 'Paris'),
('BioGen', 'info@biogen.com', 'Biotech innovation company', 'Lyon'),
('FinTech Solutions', 'support@fintech.com', 'FinTech company', 'Marseille');

-- Insérer dans la table USERS
INSERT INTO `users` (`last_name`, `first_name`, `email`, `phone`, `description`, `password`) VALUES 
('Doe', 'John', 'john.doe@gmail.com', 0612121212, 'I like Java, please hire me!', 'password123'),
('Smith', 'Jane', 'jane.smith@outlook.com', 0634343434, "I'm looking for a job in DataScience",'password456'),
('Brown', 'Emily', 'emily.brown@gmail.com', 0656565656, 'En recherche de postes en biotechnologie', 'password789');

-- Insérer dans la table ADVERTISEMENTS
INSERT INTO `advertisements` (`title`, `short_description`, `long_description`, `contract_type`, `salary`,`creation_date`, `cmp_id`) VALUES 
('Software Developer', 'Looking for a full-stack developer', 'We are seeking a full-stack developer with experience in JavaScript and Java.', 'CDI', '30', NOW(), 1),
('Biotech Engineer', 'Seeking a senior engineer', 'BioGen is hiring a senior biotech engineer to work on innovative projects.', 'CDD', '50', NOW(), 2),
('Data Scientist', 'Data Science role in FinTech', 'FinTech Solutions is looking for a data scientist to help develop predictive models.', 'CDI', '35', NOW(), 3);

-- Insérer dans la table APPLICATION
INSERT INTO `application` (`application_date`, `message`, `ad_id`, `user_id`) VALUES 
(NOW(), 'I am interested in the Software Developer role.', 1, 1),
(NOW(), 'I would like to apply for the Biotech Engineer position.', 2, 3),
(NOW(), 'I am a passionate data scientist eager to join FinTech Solutions.', 3, 2);
