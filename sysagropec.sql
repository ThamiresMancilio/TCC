-- MySQL Script generated by MySQL Workbench
-- Thu Nov 30 13:59:22 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sysagropec
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sysagropec
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sysagropec` DEFAULT CHARACTER SET utf8 ;
USE `sysagropec` ;

-- -----------------------------------------------------
-- Table `sysagropec`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Usuario` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(155) NOT NULL,
  `Sobrenome` VARCHAR(255) NULL DEFAULT NULL,
  `Login` VARCHAR(45) NOT NULL,
  `Senha` VARCHAR(45) NOT NULL,
  `Admin` TINYINT(4) NOT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Dataultimoacesso` DATETIME NULL DEFAULT NULL,
  `Excluido` TINYINT(4) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Livro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Livro` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(45) NOT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Excluido` TINYINT(4) NULL DEFAULT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_livro_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_livro_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_livro_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_livro_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Propriedade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Propriedade` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Cnpj` VARCHAR(14) NOT NULL,
  `Razaosocial` VARCHAR(255) NOT NULL,
  `Nomefantasia` VARCHAR(255) NULL DEFAULT NULL,
  `Inscricaomunicipal` VARCHAR(255) NULL DEFAULT NULL,
  `Inscricaoestadual` VARCHAR(255) NULL DEFAULT NULL,
  `Cep` VARCHAR(45) NULL DEFAULT NULL,
  `Logradouro` VARCHAR(255) NULL DEFAULT NULL,
  `Numero` VARCHAR(45) NULL DEFAULT NULL,
  `Complemento` VARCHAR(255) NULL DEFAULT NULL,
  `Bairro` VARCHAR(255) NULL DEFAULT NULL,
  `Cidade` VARCHAR(255) NULL DEFAULT NULL,
  `Estado` VARCHAR(45) NULL DEFAULT NULL,
  `Logo` VARCHAR(255) NULL DEFAULT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Dataalteracao` DATETIME NULL DEFAULT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  `Email` VARCHAR(100) NULL DEFAULT NULL,
  `Email2` VARCHAR(100) NULL DEFAULT NULL,
  `Telefone` VARCHAR(50) NULL DEFAULT NULL,
  `Telefone2` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_propriedades_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_propriedades_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_propriedades_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_propriedades_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Raca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Raca` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(255) NOT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Usuario_IDCcadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  `Excluido` TINYINT(4) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_racas_usuarios1_idx` (`Usuario_IDCcadastro` ASC),
  INDEX `fk_racas_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_racas_usuarios1`
    FOREIGN KEY (`Usuario_IDCcadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_racas_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Animal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Animal` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(200) NOT NULL,
  `Registro` VARCHAR(45) NULL DEFAULT NULL,
  `Tatuagem` VARCHAR(45) NULL DEFAULT NULL,
  `Numerobrinco` INT(11) NULL DEFAULT NULL,
  `Datanascimento` DATE NULL DEFAULT NULL,
  `Morto` TINYINT(4) NULL DEFAULT '0',
  `Observacao` TEXT NULL DEFAULT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Registropai` VARCHAR(45) NULL DEFAULT NULL,
  `Tatuagempai` VARCHAR(45) NULL DEFAULT NULL,
  `Descricaopai` VARCHAR(45) NULL DEFAULT NULL,
  `Registromae` VARCHAR(45) NULL DEFAULT NULL,
  `Tatuagemae` VARCHAR(45) NULL DEFAULT NULL,
  `Descricaomae` VARCHAR(45) NULL DEFAULT NULL,
  `Sexo` INT(11) NULL DEFAULT NULL,
  `Lactacao` TINYINT(4) NULL DEFAULT '0',
  `Dias_lactacao` INT(11) NULL DEFAULT NULL,
  `Datalactacao` DATETIME NULL DEFAULT NULL,
  `Livro_ID` INT(11) NOT NULL,
  `Raca_ID` INT(11) NOT NULL,
  `Propriedade_ID` INT(11) NOT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `id_UNIQUE` (`ID` ASC),
  INDEX `fk_animais_racas1_idx` (`Raca_ID` ASC),
  INDEX `fk_animais_propriedades1_idx` (`Propriedade_ID` ASC),
  INDEX `fk_animais_livro1_idx` (`Livro_ID` ASC),
  INDEX `fk_animais_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_animais_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_animais_livro1`
    FOREIGN KEY (`Livro_ID`)
    REFERENCES `sysagropec`.`Livro` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_animais_propriedades1`
    FOREIGN KEY (`Propriedade_ID`)
    REFERENCES `sysagropec`.`Propriedade` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_animais_racas1`
    FOREIGN KEY (`Raca_ID`)
    REFERENCES `sysagropec`.`Raca` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_animais_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_animais_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Lote`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Lote` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Numerolote` VARCHAR(45) NOT NULL,
  `Datafabricacao` DATE NOT NULL,
  `Datavalidade` DATE NOT NULL,
  `Observacao` TEXT NULL DEFAULT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Dataalteracao` DATETIME NULL DEFAULT NULL,
  `Propriedade_ID` INT(11) NOT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_lote_medicamentos_propriedades1_idx` (`Propriedade_ID` ASC),
  INDEX `fk_lote_medicamentos_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_lote_medicamentos_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_lote_medicamentos_propriedades1`
    FOREIGN KEY (`Propriedade_ID`)
    REFERENCES `sysagropec`.`Propriedade` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_lote_medicamentos_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_lote_medicamentos_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Medicamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Medicamento` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(45) NOT NULL,
  `Descricao` VARCHAR(200) NULL DEFAULT NULL,
  `Carencialeite` INT(11) NULL DEFAULT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Lote_ID` INT(11) NOT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  `Estocado` TINYINT(4) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_medicamento_lote_medicamentos1_idx` (`Lote_ID` ASC),
  INDEX `fk_medicamento_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_medicamento_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_medicamento_lote_medicamentos1`
    FOREIGN KEY (`Lote_ID`)
    REFERENCES `sysagropec`.`Lote` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_medicamento_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_medicamento_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Aplicacao_Medicamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Aplicacao_Medicamento` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Dataplicacao` DATETIME NOT NULL,
  `Quantidade` INT(11) NULL DEFAULT NULL,
  `Observacao` TEXT NULL DEFAULT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Animal_ID` INT(11) NOT NULL,
  `Medicamento_ID` INT(11) NOT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_aplicacao_medicamentos_animais1_idx` (`Animal_ID` ASC),
  INDEX `fk_aplicacao_medicamentos_medicamento1_idx` (`Medicamento_ID` ASC),
  INDEX `fk_aplicacao_medicamentos_usuarios1_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_aplicacao_medicamentos_usuarios2_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_aplicacao_medicamentos_animais1`
    FOREIGN KEY (`Animal_ID`)
    REFERENCES `sysagropec`.`Animal` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_aplicacao_medicamentos_medicamento1`
    FOREIGN KEY (`Medicamento_ID`)
    REFERENCES `sysagropec`.`Medicamento` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_aplicacao_medicamentos_usuarios1`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_aplicacao_medicamentos_usuarios2`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Estoque_Medicamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Estoque_Medicamento` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Quantidademinima` INT(11) NULL DEFAULT NULL,
  `Quantidademaxima` INT(11) NULL DEFAULT NULL,
  `Quantidadeatual` INT(11) NULL DEFAULT NULL,
  `Medicamento_ID` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  `Data_Estocado` DATETIME NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_estoque_medicamentos_medicamento1_idx` (`Medicamento_ID` ASC),
  INDEX `fk_estoque_medicamentos_usuarios1_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_estoque_medicamentos_medicamento1`
    FOREIGN KEY (`Medicamento_ID`)
    REFERENCES `sysagropec`.`Medicamento` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_estoque_medicamentos_usuarios1`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Producao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Producao` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Datarealizada` DATETIME NOT NULL,
  `Quantidade` DOUBLE NOT NULL,
  `Datacadastro` DATETIME NOT NULL,
  `Datalteracao` DATETIME NULL DEFAULT NULL,
  `Excluido` TINYINT(4) NULL DEFAULT NULL,
  `Observacao` TEXT NULL DEFAULT NULL,
  `Animail_ID` INT(11) NOT NULL,
  `Usuario_IDProducao` INT(11) NOT NULL,
  `Usuario_IDCadastro` INT(11) NOT NULL,
  `Usuario_IDAlteracao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_producoes_animais_idx` (`Animail_ID` ASC),
  INDEX `fk_producoes_usuarios1_idx` (`Usuario_IDProducao` ASC),
  INDEX `fk_producoes_usuarios2_idx` (`Usuario_IDCadastro` ASC),
  INDEX `fk_producoes_usuarios3_idx` (`Usuario_IDAlteracao` ASC),
  CONSTRAINT `fk_producoes_animais`
    FOREIGN KEY (`Animail_ID`)
    REFERENCES `sysagropec`.`Animal` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_producoes_usuarios1`
    FOREIGN KEY (`Usuario_IDProducao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_producoes_usuarios2`
    FOREIGN KEY (`Usuario_IDCadastro`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_producoes_usuarios3`
    FOREIGN KEY (`Usuario_IDAlteracao`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 34
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sysagropec`.`Usuario_Propriedade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysagropec`.`Usuario_Propriedade` (
  `Usuario_id` INT(11) NOT NULL,
  `Propriedade_id` INT(11) NOT NULL,
  PRIMARY KEY (`Usuario_id`, `Propriedade_id`),
  INDEX `fk_usuarios_has_propriedades_propriedades1_idx` (`Propriedade_id` ASC),
  INDEX `fk_usuarios_has_propriedades_usuarios1_idx` (`Usuario_id` ASC),
  CONSTRAINT `fk_usuarios_has_propriedades_propriedades1`
    FOREIGN KEY (`Propriedade_id`)
    REFERENCES `sysagropec`.`Propriedade` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_has_propriedades_usuarios1`
    FOREIGN KEY (`Usuario_id`)
    REFERENCES `sysagropec`.`Usuario` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
