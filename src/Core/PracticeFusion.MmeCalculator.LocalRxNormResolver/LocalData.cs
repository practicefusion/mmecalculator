﻿using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.LocalRxNormResolver
{
    internal class LocalData
    {
        // From NIH Value Set Authority Center:
        // 
        // Value Set Name       Opioids, All
        // Code System          RXNORM
        // OID	                2.16.840.1.113762.1.4.1196.226
        // Type                 Extensional
        // Definition Version   20191126
        // Steward              IMPAQ International

        static LocalData()
        {
            Codes = new Dictionary<string, string>
            {
                { "1010600", "Buprenorphine 2 MG / Naloxone 0.5 MG Sublingual Film" },
                { "1010603", "Buprenorphine 2 MG / Naloxone 0.5 MG Sublingual Film [Suboxone]" },
                { "1010604", "Buprenorphine 8 MG / Naloxone 2 MG Sublingual Film" },
                { "1010606", "Buprenorphine 8 MG / Naloxone 2 MG Sublingual Film [Suboxone]" },
                { "1010608", "Buprenorphine 2 MG / Naloxone 0.5 MG Sublingual Tablet [Suboxone]" },
                { "1010609", "Buprenorphine 8 MG / Naloxone 2 MG Sublingual Tablet [Suboxone]" },
                { "1014599", "Acetaminophen 300 MG / Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1014615", "Acetaminophen 300 MG / Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1014632", "Acetaminophen 300 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet" },
                { "1037259", "Acetaminophen 300 MG / Oxycodone Hydrochloride 2.5 MG Oral Tablet" },
                {
                    "1042693",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution"
                },
                { "1044427", "Acetaminophen 20 MG/ML / Hydrocodone Bitartrate 0.667 MG/ML Oral Solution" },
                { "1049214", "Acetaminophen 325 MG / Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1049216", "Acetaminophen 325 MG / Oxycodone Hydrochloride 10 MG Oral Tablet [Endocet]" },
                { "1049221", "Acetaminophen 325 MG / Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1049223", "Acetaminophen 325 MG / Oxycodone Hydrochloride 5 MG Oral Tablet [Endocet]" },
                { "1049225", "Acetaminophen 325 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet" },
                { "1049227", "Acetaminophen 325 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet [Endocet]" },
                { "1049233", "Acetaminophen 500 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet" },
                { "1049251", "Acetaminophen 400 MG / Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1049260", "Acetaminophen 400 MG / Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1049267", "Acetaminophen 400 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet" },
                { "1049270", "Acetaminophen 650 MG / Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1049502", "12 HR Oxycodone Hydrochloride 10 MG Extended Release Oral Tablet" },
                {
                    "1049504",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 10 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049543", "12 HR Oxycodone Hydrochloride 15 MG Extended Release Oral Tablet" },
                {
                    "1049545",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 15 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049563", "12 HR Oxycodone Hydrochloride 20 MG Extended Release Oral Tablet" },
                {
                    "1049565",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 20 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049574", "12 HR Oxycodone Hydrochloride 30 MG Extended Release Oral Tablet" },
                {
                    "1049576",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 30 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049580", "Acetaminophen 65 MG/ML / Oxycodone Hydrochloride 1 MG/ML Oral Solution" },
                { "1049582", "Acetaminophen 65 MG/ML / Oxycodone Hydrochloride 1 MG/ML Oral Solution [Roxicet]" },
                { "1049584", "12 HR Oxycodone Hydrochloride 40 MG Extended Release Oral Tablet" },
                {
                    "1049586",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 40 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049589", "Ibuprofen 400 MG / Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1049593", "12 HR Oxycodone Hydrochloride 60 MG Extended Release Oral Tablet" },
                {
                    "1049595",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 60 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049599", "12 HR Oxycodone Hydrochloride 80 MG Extended Release Oral Tablet" },
                {
                    "1049601",
                    "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 80 MG Extended Release Oral Tablet [Oxycontin]"
                },
                { "1049604", "Oxycodone Hydrochloride 1 MG/ML Oral Solution" },
                { "1049611", "Oxycodone Hydrochloride 15 MG Oral Tablet" },
                { "1049613", "Oxycodone Hydrochloride 15 MG Oral Tablet [Roxicodone]" },
                { "1049615", "Oxycodone Hydrochloride 20 MG/ML Oral Solution" },
                { "1049618", "Oxycodone Hydrochloride 30 MG Oral Tablet" },
                { "1049620", "Oxycodone Hydrochloride 30 MG Oral Tablet [Roxicodone]" },
                { "1049621", "Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1049623", "Oxycodone Hydrochloride 5 MG Oral Tablet [Roxicodone]" },
                { "1049625", "Acetaminophen 325 MG / Oxycodone Hydrochloride 10 MG Oral Tablet [Percocet]" },
                { "1049635", "Acetaminophen 325 MG / Oxycodone Hydrochloride 2.5 MG Oral Tablet" },
                { "1049637", "Acetaminophen 325 MG / Oxycodone Hydrochloride 2.5 MG Oral Tablet [Percocet]" },
                { "1049640", "Acetaminophen 325 MG / Oxycodone Hydrochloride 5 MG Oral Tablet [Percocet]" },
                { "1049642", "Acetaminophen 325 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet [Percocet]" },
                { "1049647", "Acetaminophen 500 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet [Percocet]" },
                { "1049650", "Acetaminophen 650 MG / Oxycodone Hydrochloride 10 MG Oral Tablet [Percocet]" },
                { "1049651", "Acetaminophen 500 MG / Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1049655", "Acetaminophen 500 MG / Oxycodone Hydrochloride 10 MG Oral Tablet [Xolox]" },
                { "1049658", "Acetaminophen 500 MG / Oxycodone Hydrochloride 5 MG Oral Capsule" },
                { "1049683", "Oxycodone Hydrochloride 10 MG Oral Tablet" },
                { "1049686", "Oxycodone Hydrochloride 20 MG Oral Tablet" },
                { "1049691", "Aspirin 325 MG / Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1049696", "Oxycodone Hydrochloride 5 MG Oral Capsule" },
                { "1049717", "Oxycodone Hydrochloride 10 MG Oral Capsule" },
                { "1049719", "Oxycodone Hydrochloride 10 MG/ML Injectable Solution" },
                { "1049720", "Oxycodone Hydrochloride 10 MG/ML Oral Solution" },
                { "1049721", "Oxycodone Hydrochloride 20 MG Oral Capsule" },
                { "1049727", "Oxycodone Hydrochloride 5 MG Extended Release Oral Tablet" },
                { "1050409", "Oxycodone Hydrochloride 20 MG/ML Oral Solution [Oxyfast]" },
                { "1050490", "Acetaminophen 325 MG / Oxycodone Hydrochloride 5 MG Oral Tablet [Roxicet]" },
                { "1053647", "Fentanyl 0.1 MG Sublingual Tablet" },
                { "1053651", "Fentanyl 0.1 MG Sublingual Tablet [Abstral]" },
                { "1053652", "Fentanyl 0.2 MG Sublingual Tablet" },
                { "1053654", "Fentanyl 0.2 MG Sublingual Tablet [Abstral]" },
                { "1053655", "Fentanyl 0.3 MG Sublingual Tablet" },
                { "1053657", "Fentanyl 0.3 MG Sublingual Tablet [Abstral]" },
                { "1053658", "Fentanyl 0.4 MG Sublingual Tablet" },
                { "1053660", "Fentanyl 0.4 MG Sublingual Tablet [Abstral]" },
                { "1053661", "Fentanyl 0.6 MG Sublingual Tablet" },
                { "1053663", "Fentanyl 0.6 MG Sublingual Tablet [Abstral]" },
                { "1053664", "Fentanyl 0.8 MG Sublingual Tablet" },
                { "1053666", "Fentanyl 0.8 MG Sublingual Tablet [Abstral]" },
                { "106500", "Alfentanil 5 MG/ML Injectable Solution" },
                { "106505", "Meptazinol 200 MG Oral Tablet" },
                { "1086926", "Codeine Phosphate 1.26 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Relcof C]" },
                {
                    "1087389",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 4 MG / HYDROCODONE POLISTIREX 5 MG Extended Release Oral Capsule [TussiCaps]"
                },
                {
                    "1087427",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 8 MG / HYDROCODONE POLISTIREX 10 MG Extended Release Oral Capsule [TussiCaps]"
                },
                {
                    "1087459",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 1.6 MG/ML / HYDROCODONE POLISTIREX 2 MG/ML Extended Release Suspension"
                },
                {
                    "1087463",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 1.6 MG/ML / HYDROCODONE POLISTIREX 2 MG/ML Extended Release Suspension [Tussionex]"
                },
                {
                    "1088951",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3 MG/ML Oral Suspension"
                },
                {
                    "1088953",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1088963",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3.33 MG/ML Oral Suspension"
                },
                {
                    "1088965",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3.33 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1088968",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3.75 MG/ML Oral Suspension"
                },
                {
                    "1088970",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 3.75 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1088975",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Suspension"
                },
                {
                    "1088977",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1089021",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 4.29 MG/ML Oral Suspension"
                },
                {
                    "1089023",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 4.29 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1089025",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 5 MG/ML Oral Suspension"
                },
                {
                    "1089027",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 5 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1089028",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Suspension"
                },
                {
                    "1089030",
                    "Codeine Phosphate 1 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Suspension [Zodryl DEC]"
                },
                {
                    "1089055",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 20 MG Oral Tablet"
                },
                {
                    "1089057",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 20 MG Oral Tablet [Ambifed-G CD]"
                },
                {
                    "1089058",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet"
                },
                {
                    "1089060",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet [Ambifed CD]"
                },
                {
                    "1089061",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 40 MG Oral Tablet"
                },
                {
                    "1089063",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 40 MG Oral Tablet [Maxifed-G CD]"
                },
                {
                    "1089070",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet"
                },
                {
                    "1089072",
                    "Codeine Phosphate 10 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet [Maxifed CD]"
                },
                {
                    "1098906",
                    "Brompheniramine Maleate 0.4 MG/ML / Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution"
                },
                {
                    "1099711",
                    "Codeine Phosphate 20 MG / Pseudoephedrine Hydrochloride 60 MG / Triprolidine Hydrochloride 4 MG Oral Tablet"
                },
                {
                    "1112220",
                    "Chlorpheniramine Maleate 0.8 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 12 MG/ML Oral Solution"
                },
                {
                    "1112224",
                    "Chlorpheniramine Maleate 0.8 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 12 MG/ML Oral Solution [Zutripro]"
                },
                { "1113314", "Oxycodone Hydrochloride 7.5 MG Oral Tablet" },
                {
                    "1113417",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "1113437",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Phenylhistine DH]"
                },
                { "1113998", "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.6 MG/ML Oral Solution" },
                {
                    "1114002",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.6 MG/ML Oral Solution [Codar AR]"
                },
                {
                    "1114003",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.6 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                { "1114026", "Codeine Phosphate 1.6 MG/ML / Guaifenesin 40 MG/ML Oral Solution" },
                { "1114030", "Codeine Phosphate 1.6 MG/ML / Guaifenesin 40 MG/ML Oral Solution [Codar GF]" },
                {
                    "1114110",
                    "Codeine Phosphate 1.6 MG/ML / Guaifenesin 40 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "1114334",
                    "Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 12 MG/ML Oral Solution"
                },
                {
                    "1114338",
                    "Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 12 MG/ML Oral Solution [Rezira]"
                },
                { "1114878", "Codeine Phosphate 1.6 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution" },
                { "1115573", "Fentanyl 0.1 MG/ACTUAT Metered Dose Nasal Spray" },
                { "1115575", "Fentanyl 0.1 MG/ACTUAT Metered Dose Nasal Spray [Lazanda]" },
                { "1115577", "Fentanyl 0.4 MG/ACTUAT Metered Dose Nasal Spray" },
                { "1115579", "Fentanyl 0.4 MG/ACTUAT Metered Dose Nasal Spray [Lazanda]" },
                {
                    "1145972",
                    "Codeine Phosphate 1.6 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Codar D]"
                },
                { "1147395", "Acetaminophen 325 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Xodol]" },
                { "1148478", "24 HR tramadol hydrochloride 100 MG Extended Release Oral Capsule" },
                { "1148482", "24 HR tramadol hydrochloride 100 MG Extended Release Oral Capsule [ConZip]" },
                { "1148485", "24 HR tramadol hydrochloride 200 MG Extended Release Oral Capsule" },
                { "1148487", "24 HR tramadol hydrochloride 200 MG Extended Release Oral Capsule [ConZip]" },
                { "1148489", "24 HR tramadol hydrochloride 300 MG Extended Release Oral Capsule" },
                { "1148491", "24 HR tramadol hydrochloride 300 MG Extended Release Oral Capsule [ConZip]" },
                { "1148797", "12 HR tapentadol 100 MG Extended Release Oral Tablet" },
                { "1148800", "12 HR tapentadol 150 MG Extended Release Oral Tablet" },
                { "1148803", "12 HR tapentadol 200 MG Extended Release Oral Tablet" },
                { "1148807", "12 HR tapentadol 250 MG Extended Release Oral Tablet" },
                { "1148809", "12 HR tapentadol 50 MG Extended Release Oral Tablet" },
                { "1149367", "12 HR tapentadol 100 MG Extended Release Oral Tablet [Nucynta]" },
                { "1149370", "12 HR tapentadol 150 MG Extended Release Oral Tablet [Nucynta]" },
                { "1149373", "12 HR tapentadol 200 MG Extended Release Oral Tablet [Nucynta]" },
                { "1149376", "12 HR tapentadol 250 MG Extended Release Oral Tablet [Nucynta]" },
                { "1149378", "12 HR tapentadol 50 MG Extended Release Oral Tablet [Nucynta]" },
                {
                    "1190201",
                    "Acetaminophen 320.5 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule [Trezix]"
                },
                { "1190568", "Atropine Sulfate 0.005 MG/ML / Diphenoxylate Hydrochloride 0.5 MG/ML Oral Solution" },
                { "1190572", "Atropine Sulfate 0.025 MG / Diphenoxylate Hydrochloride 2.5 MG Oral Tablet" },
                {
                    "1190580",
                    "Codeine Phosphate 1.2 MG/ML / Dexbrompheniramine maleate 0.133 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Solution"
                },
                {
                    "1190587",
                    "Codeine Phosphate 1.2 MG/ML / Dexbrompheniramine maleate 0.133 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Solution [M-End Max D]"
                },
                {
                    "1190641",
                    "Atropine Sulfate 0.025 MG / Diphenoxylate Hydrochloride 2.5 MG Oral Tablet [Lomotil]"
                },
                { "1190646", "Atropine Sulfate 0.025 MG / Diphenoxylate Hydrochloride 2.5 MG Oral Tablet [Lonox]" },
                { "1232113", "1 ML Morphine Sulfate 15 MG/ML Prefilled Syringe" },
                { "1233685", "Fentanyl 0.003 MG/ML / Ropivacaine hydrochloride 2.5 MG/ML Injectable Solution" },
                { "1233686", "Fentanyl 0.004 MG/ML / Ropivacaine hydrochloride 1 MG/ML Injectable Solution" },
                { "1233687", "Fentanyl 0.004 MG/ML / Ropivacaine hydrochloride 2 MG/ML Injectable Solution" },
                { "1233700", "Hydromorphone Hydrochloride 0.01 MG/ML Injectable Solution" },
                {
                    "1234871",
                    "Acetaminophen 356.4 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule"
                },
                { "1234872", "Aspirin 356.4 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule" },
                {
                    "1234941",
                    "Chlorpheniramine Maleate 0.4 MG/ML / dihydrocodeine bitartrate 0.6 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution"
                },
                {
                    "1234957",
                    "Chlorpheniramine Maleate 0.4 MG/ML / dihydrocodeine bitartrate 0.6 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [ColdCough PD]"
                },
                {
                    "1234976",
                    "Aspirin 356.4 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule [Synalgos-DC]"
                },
                {
                    "1234978",
                    "Acetaminophen 712.8 MG / Caffeine 60 MG / dihydrocodeine bitartrate 32 MG Oral Tablet"
                },
                {
                    "1234990",
                    "Acetaminophen 356.4 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule [Trezix]"
                },
                { "1234999", "Acetaminophen 500 MG / dihydrocodeine bitartrate 10 MG Oral Tablet" },
                { "1235009", "Acetaminophen 500 MG / dihydrocodeine bitartrate 20 MG Oral Tablet" },
                { "1235011", "Acetaminophen 500 MG / dihydrocodeine bitartrate 30 MG Oral Tablet" },
                {
                    "1235862",
                    "Chlorcyclizine hydrochloride 2.5 MG/ML / Codeine Phosphate 1.8 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                { "1236179", "dihydrocodeine bitartrate 120 MG Extended Release Oral Tablet" },
                { "1236182", "dihydrocodeine bitartrate 30 MG Oral Tablet" },
                { "1236184", "dihydrocodeine bitartrate 40 MG Oral Tablet" },
                { "1236188", "dihydrocodeine bitartrate 60 MG Extended Release Oral Tablet" },
                { "1236190", "dihydrocodeine bitartrate 90 MG Extended Release Oral Tablet" },
                { "1236239", "dihydrocodeine bitartrate 60 MG Oral Tablet" },
                { "1237050", "Fentanyl 0.1 MG/ACTUAT Mucosal Spray" },
                { "1237055", "Fentanyl 0.1 MG/ACTUAT Mucosal Spray [Subsys]" },
                { "1237057", "Fentanyl 0.2 MG/ACTUAT Mucosal Spray" },
                { "1237059", "Fentanyl 0.2 MG/ACTUAT Mucosal Spray [Subsys]" },
                { "1237060", "Fentanyl 0.4 MG/ACTUAT Mucosal Spray" },
                { "1237062", "Fentanyl 0.4 MG/ACTUAT Mucosal Spray [Subsys]" },
                { "1237064", "Fentanyl 0.6 MG/ACTUAT Mucosal Spray" },
                { "1237066", "Fentanyl 0.6 MG/ACTUAT Mucosal Spray [Subsys]" },
                { "1237068", "Fentanyl 0.8 MG/ACTUAT Mucosal Spray" },
                { "1237070", "Fentanyl 0.8 MG/ACTUAT Mucosal Spray [Subsys]" },
                { "1242106", "1 ML Meperidine Hydrochloride 100 MG/ML Cartridge [Demerol]" },
                { "1242503", "1 ML Meperidine Hydrochloride 25 MG/ML Cartridge [Demerol]" },
                {
                    "1242558",
                    "Chlorcyclizine hydrochloride 2.5 MG/ML / Codeine Phosphate 1.8 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Statuss Green Reformulated Jan 2012]"
                },
                {
                    "1244754",
                    "Guaifenesin 20 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "1244921",
                    "Brompheniramine Maleate 0.266 MG/ML / Codeine Phosphate 1.27 MG/ML / Phenylephrine Hydrochloride 0.666 MG/ML Oral Solution [M-End PE]"
                },
                { "1248115", "24 HR tramadol hydrochloride 150 MG Extended Release Oral Capsule" },
                { "1250685", "Loperamide Hydrochloride 0.133 MG/ML Oral Suspension" },
                { "1250693", "Loperamide Hydrochloride 0.133 MG/ML Oral Suspension [Imodium]" },
                {
                    "1294356",
                    "Bromodiphenhydramine hydrochloride 2.5 MG/ML / Codeine Phosphate 2 MG/ML Oral Solution"
                },
                { "1302739", "Butorphanol 10 MG/ML Injectable Solution" },
                { "1302741", "Butorphanol 10 MG/ML Injectable Solution [Dolorex Solution]" },
                { "1303736", "Morphine Sulfate 40 MG Extended Release Oral Capsule" },
                { "1303738", "Morphine Sulfate 40 MG Extended Release Oral Capsule [Kadian]" },
                { "1306898", "24 HR Hydromorphone Hydrochloride 32 MG Extended Release Oral Tablet" },
                { "1306900", "24 HR Hydromorphone Hydrochloride 32 MG Extended Release Oral Tablet [Exalgo]" },
                { "1307056", "Buprenorphine 4 MG / Naloxone 1 MG Sublingual Film" },
                { "1307058", "Buprenorphine 4 MG / Naloxone 1 MG Sublingual Film [Suboxone]" },
                { "1307061", "Buprenorphine 12 MG / Naloxone 3 MG Sublingual Film" },
                { "1307063", "Buprenorphine 12 MG / Naloxone 3 MG Sublingual Film [Suboxone]" },
                { "1308438", "Brompheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML Oral Solution" },
                {
                    "1308440",
                    "Brompheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML Oral Solution [Nalex AC]"
                },
                { "1310202", "Acetaminophen 300 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Vicodin]" },
                { "1310212", "Acetaminophen 300 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Vicodin]" },
                { "1310270", "Acetaminophen 300 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Vicodin]" },
                { "1310927", "Butorphanol 10 MG/ML Injectable Solution [Butorphic]" },
                {
                    "1313294",
                    "Guaifenesin 10 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution"
                },
                { "1356315", "tapentadol 20 MG/ML Oral Solution" },
                {
                    "1356797",
                    "Brompheniramine Maleate 4 MG / Codeine Phosphate 10 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet"
                },
                {
                    "1356799",
                    "Brompheniramine Maleate 4 MG / Codeine Phosphate 10 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet [Brovex PBC]"
                },
                { "1356800", "Brompheniramine Maleate 4 MG / Codeine Phosphate 10 MG Oral Tablet" },
                { "1356802", "Brompheniramine Maleate 4 MG / Codeine Phosphate 10 MG Oral Tablet [BroveX CB]" },
                {
                    "1356804",
                    "Brompheniramine Maleate 4 MG / Codeine Phosphate 20 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet"
                },
                {
                    "1356806",
                    "Brompheniramine Maleate 4 MG / Codeine Phosphate 20 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet [Brovex PBC]"
                },
                { "1356807", "Brompheniramine Maleate 4 MG / Codeine Phosphate 20 MG Oral Tablet" },
                { "1356809", "Brompheniramine Maleate 4 MG / Codeine Phosphate 20 MG Oral Tablet [BroveX CB]" },
                {
                    "1356835",
                    "Brompheniramine Maleate 0.6 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "1357402",
                    "Brompheniramine Maleate 0.4 MG/ML / Codeine Phosphate 2 MG/ML / Phenylpropanolamine Hydrochloride 2.5 MG/ML Oral Solution"
                },
                {
                    "1357940",
                    "Dexchlorpheniramine maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.8 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution"
                },
                { "1366873", "Hydrocodone Bitartrate 5 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet" },
                {
                    "1366875",
                    "Hydrocodone Bitartrate 5 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet [P-V-Tussin]"
                },
                { "1372265", "Chlorpheniramine Maleate 0.8 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution" },
                {
                    "1372873",
                    "Chlorpheniramine Maleate 0.8 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution [Vituz]"
                },
                {
                    "1424295",
                    "Acetaminophen 325 MG / Chlorpheniramine Maleate 2 MG / Codeine Phosphate 8 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet"
                },
                {
                    "1424297",
                    "Acetaminophen 500 MG / Codeine Phosphate 6 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet"
                },
                { "1431076", "Buprenorphine 1.4 MG / Naloxone 0.36 MG Sublingual Tablet" },
                { "1431083", "Buprenorphine 1.4 MG / Naloxone 0.36 MG Sublingual Tablet [Zubsolv]" },
                { "1431102", "Buprenorphine 5.7 MG / Naloxone 1.4 MG Sublingual Tablet" },
                { "1431104", "Buprenorphine 5.7 MG / Naloxone 1.4 MG Sublingual Tablet [Zubsolv]" },
                {
                    "1431286",
                    "Acetaminophen 300 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule"
                },
                { "1432969", "168 HR Buprenorphine 0.015 MG/HR Transdermal System" },
                { "1432971", "168 HR Buprenorphine 0.015 MG/HR Transdermal System [BuTrans]" },
                { "1433251", "0.5 ML Hydromorphone Hydrochloride 1 MG/ML Prefilled Syringe" },
                {
                    "1433802",
                    "Acetaminophen 300 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule [Fioricet with Codeine]"
                },
                {
                    "1440003",
                    "Codeine Phosphate 1.8 MG/ML / Dexchlorpheniramine maleate 0.2 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution"
                },
                { "1442445", "Acetaminophen 20 MG/ML / Hydrocodone Bitartrate 0.667 MG/ML Oral Solution [Lortab]" },
                { "1442790", "1 ML Morphine Sulfate 5 MG/ML Prefilled Syringe" },
                { "1487288", "Acetaminophen 325 MG / Oxycodone Hydrochloride 2.5 MG Oral Tablet [Endocet]" },
                { "1488634", "Buprenorphine hydrochloride 1.3 MG/ML Injectable Suspension" },
                { "1488639", "Buprenorphine hydrochloride 1.3 MG/ML Injectable Suspension [Animalgesics]" },
                { "1489991", "Butorphanol 10 MG/ML Injectable Solution [Torbugesic]" },
                {
                    "1491832",
                    "12 HR Acetaminophen 325 MG / Oxycodone Hydrochloride 7.5 MG Extended Release Oral Tablet"
                },
                {
                    "1491834",
                    "12 HR Acetaminophen 325 MG / Oxycodone Hydrochloride 7.5 MG Extended Release Oral Tablet [Xartemis]"
                },
                { "1492671", "Acetaminophen 325 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Lorcet]" },
                { "1492673", "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Lorcet]" },
                { "1492675", "Acetaminophen 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Lorcet]" },
                { "1495472", "Acetaminophen 325 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Lortab]" },
                { "1495474", "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Lortab]" },
                { "1495476", "Acetaminophen 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Lortab]" },
                {
                    "1535979",
                    "Chlorpheniramine Maleate 0.5 MG/ML / Hydrocodone Bitartrate 0.65 MG/ML / Phenylephrine Hydrochloride 1.6 MG/ML Oral Solution"
                },
                { "1536457", "Acetaminophen 500 MG / Codeine Phosphate 8 MG Effervescent Oral Tablet" },
                { "1536459", "Acetaminophen 500 MG / Codeine Phosphate 30 MG Effervescent Oral Tablet" },
                { "1537116", "Acetaminophen 300 MG / Oxycodone Hydrochloride 5 MG Oral Tablet [Primlev]" },
                { "1537120", "Acetaminophen 300 MG / Oxycodone Hydrochloride 10 MG Oral Tablet [Primlev]" },
                { "1537122", "Acetaminophen 300 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet [Primlev]" },
                {
                    "1541630",
                    "Brompheniramine Maleate 0.8 MG/ML / Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                { "1542390", "Buprenorphine 2.1 MG / Naloxone 0.3 MG Buccal Film" },
                { "1542396", "Buprenorphine 2.1 MG / Naloxone 0.3 MG Buccal Film [Bunavail]" },
                { "1542981", "Acetaminophen 325 MG / Hydrocodone Bitartrate 2.5 MG Oral Tablet [Verdrocet]" },
                { "1542988", "Hydrocodone Bitartrate 10 MG / Ibuprofen 200 MG Oral Tablet [Xylon]" },
                { "1542997", "168 HR Buprenorphine 0.0075 MG/HR Transdermal System" },
                { "1542999", "168 HR Buprenorphine 0.0075 MG/HR Transdermal System [BuTrans]" },
                { "1544851", "Buprenorphine 4.2 MG / Naloxone 0.7 MG Buccal Film" },
                { "1544853", "Buprenorphine 4.2 MG / Naloxone 0.7 MG Buccal Film [Bunavail]" },
                { "1544854", "Buprenorphine 6.3 MG / Naloxone 1 MG Buccal Film" },
                { "1544856", "Buprenorphine 6.3 MG / Naloxone 1 MG Buccal Film [Bunavail]" },
                {
                    "1545903",
                    "12 HR Naloxone Hydrochloride 10 MG / Oxycodone Hydrochloride 20 MG Extended Release Oral Tablet"
                },
                {
                    "1545907",
                    "12 HR Naloxone Hydrochloride 20 MG / Oxycodone Hydrochloride 40 MG Extended Release Oral Tablet"
                },
                {
                    "1545910",
                    "12 HR Naloxone Hydrochloride 5 MG / Oxycodone Hydrochloride 10 MG Extended Release Oral Tablet"
                },
                {
                    "1546089",
                    "12 HR Naloxone Hydrochloride 5 MG / Oxycodone Hydrochloride 10 MG Extended Release Oral Tablet [Targiniq]"
                },
                {
                    "1547607",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Lortuss EX]"
                },
                { "1594650", "Buprenorphine 1.8 MG/ML Injectable Solution" },
                { "1594655", "Buprenorphine 1.8 MG/ML Injectable Solution [Simbadol]" },
                { "1595214", "Codeine Phosphate 1.6 MG/ML / Guaifenesin 40 MG/ML Oral Solution [Ninjacof XG]" },
                { "1595730", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 20 MG Extended Release Oral Tablet" },
                {
                    "1595736",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 20 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595740", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 30 MG Extended Release Oral Tablet" },
                {
                    "1595742",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 30 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595746", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 40 MG Extended Release Oral Tablet" },
                {
                    "1595748",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 40 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595752", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 60 MG Extended Release Oral Tablet" },
                {
                    "1595754",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 60 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595758", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 80 MG Extended Release Oral Tablet" },
                {
                    "1595760",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 80 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595764", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 100 MG Extended Release Oral Tablet" },
                {
                    "1595766",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 100 MG Extended Release Oral Tablet [Hysingla]"
                },
                { "1595770", "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 120 MG Extended Release Oral Tablet" },
                {
                    "1595772",
                    "Abuse-Deterrent 24 HR Hydrocodone Bitartrate 120 MG Extended Release Oral Tablet [Hysingla]"
                },
                {
                    "1596108",
                    "Acetaminophen 320.5 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Capsule"
                },
                { "1597568", "Buprenorphine 11.4 MG / Naloxone 2.9 MG Sublingual Tablet" },
                { "1597570", "Buprenorphine 11.4 MG / Naloxone 2.9 MG Sublingual Tablet [Zubsolv]" },
                { "1597573", "Buprenorphine 8.6 MG / Naloxone 2.1 MG Sublingual Tablet" },
                { "1597575", "Buprenorphine 8.6 MG / Naloxone 2.1 MG Sublingual Tablet [Zubsolv]" },
                { "1598284", "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution [Obredon]" },
                { "1603495", "72 HR Fentanyl 0.0375 MG/HR Transdermal System" },
                { "1603498", "72 HR Fentanyl 0.0625 MG/HR Transdermal System" },
                { "1603501", "72 HR Fentanyl 0.0875 MG/HR Transdermal System" },
                { "1650982", "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution [Flowtuss]" },
                {
                    "1651558",
                    "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "1651564",
                    "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Hycofenix]"
                },
                {
                    "1652087",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 0.8 MG/ML / CODEINE POLISTIREX 4 MG/ML Extended Release Suspension"
                },
                {
                    "1652093",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 0.8 MG/ML / CODEINE POLISTIREX 4 MG/ML Extended Release Suspension [Tuzistra]"
                },
                { "1655032", "1 ML Buprenorphine 0.3 MG/ML Cartridge" },
                { "1655058", "Meperidine Hydrochloride 150 MG Oral Tablet" },
                { "1655060", "Meperidine Hydrochloride 75 MG Oral Tablet" },
                {
                    "1661319",
                    "Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 2 MG/ML / Triprolidine Hydrochloride 0.5 MG/ML Oral Solution"
                },
                {
                    "1661325",
                    "Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 2 MG/ML / Triprolidine Hydrochloride 0.5 MG/ML Oral Solution [Histex AC]"
                },
                { "1664448", "Oxycodone Hydrochloride 5 MG Oral Tablet [Oxaydo]" },
                {
                    "1664543",
                    "12 HR Chlorpheniramine Maleate 8 MG / Codeine Phosphate 54.3 MG Extended Release Oral Tablet"
                },
                { "1664634", "Oxycodone Hydrochloride 7.5 MG Oral Tablet [Oxaydo]" },
                { "1665685", "1 ML Meperidine Hydrochloride 100 MG/ML Injection" },
                { "1665687", "1 ML Meperidine Hydrochloride 100 MG/ML Injection [Demerol]" },
                { "1665690", "1.5 ML Meperidine Hydrochloride 50 MG/ML Injection" },
                { "1665691", "1.5 ML Meperidine Hydrochloride 50 MG/ML Injection [Demerol]" },
                { "1665697", "1 ML Meperidine Hydrochloride 50 MG/ML Injection" },
                { "1665698", "1 ML Meperidine Hydrochloride 50 MG/ML Injection [Demerol]" },
                { "1665699", "0.5 ML Meperidine Hydrochloride 50 MG/ML Injection" },
                { "1665700", "0.5 ML Meperidine Hydrochloride 50 MG/ML Injection [Demerol]" },
                { "1665701", "2 ML Meperidine Hydrochloride 50 MG/ML Injection" },
                { "1665702", "2 ML Meperidine Hydrochloride 50 MG/ML Injection [Demerol]" },
                { "1666338", "Buprenorphine 2.9 MG / Naloxone 0.71 MG Sublingual Tablet" },
                { "1666385", "Buprenorphine 2.9 MG / Naloxone 0.71 MG Sublingual Tablet [Zubsolv]" },
                { "1666831", "80 ACTUAT Fentanyl 0.04 MG/ACTUAT Transdermal System" },
                { "1666837", "80 ACTUAT Fentanyl 0.04 MG/ACTUAT Transdermal System [Ionsys]" },
                { "1716057", "Buprenorphine 0.15 MG Buccal Film" },
                { "1716063", "Buprenorphine 0.15 MG Buccal Film [Belbuca]" },
                { "1716065", "Buprenorphine 0.3 MG Buccal Film" },
                { "1716067", "Buprenorphine 0.3 MG Buccal Film [Belbuca]" },
                { "1716069", "Buprenorphine 0.45 MG Buccal Film" },
                { "1716071", "Buprenorphine 0.45 MG Buccal Film [Belbuca]" },
                { "1716073", "Buprenorphine 0.6 MG Buccal Film" },
                { "1716075", "Buprenorphine 0.6 MG Buccal Film [Belbuca]" },
                { "1716077", "Buprenorphine 0.075 MG Buccal Film" },
                { "1716079", "Buprenorphine 0.075 MG Buccal Film [Belbuca]" },
                { "1716081", "Buprenorphine 0.75 MG Buccal Film" },
                { "1716083", "Buprenorphine 0.75 MG Buccal Film [Belbuca]" },
                { "1716086", "Buprenorphine 0.9 MG Buccal Film" },
                { "1716090", "Buprenorphine 0.9 MG Buccal Film [Belbuca]" },
                { "1723206", "2 ML Alfentanil 0.5 MG/ML Injection" },
                { "1723208", "10 ML Alfentanil 0.5 MG/ML Injection" },
                { "1723209", "20 ML Alfentanil 0.5 MG/ML Injection" },
                { "1723210", "5 ML Alfentanil 0.5 MG/ML Injection" },
                { "1724276", "1 ML Hydromorphone Hydrochloride 2 MG/ML Injection" },
                { "1724338", "1 ML Hydromorphone Hydrochloride 10 MG/ML Injection" },
                { "1724340", "5 ML Hydromorphone Hydrochloride 10 MG/ML Injection" },
                { "1724341", "50 ML Hydromorphone Hydrochloride 10 MG/ML Injection" },
                { "1724383", "1 ML Hydromorphone Hydrochloride 1 MG/ML Cartridge" },
                { "1724644", "1 ML Hydromorphone Hydrochloride 2 MG/ML Cartridge" },
                { "1728351", "1 ML Butorphanol Tartrate 2 MG/ML Injection" },
                { "1728355", "2 ML Butorphanol Tartrate 2 MG/ML Injection" },
                { "1728783", "10 ML Morphine Sulfate 0.5 MG/ML Injection" },
                { "1728784", "10 ML Morphine Sulfate 0.5 MG/ML Injection [Astramorph]" },
                { "1728791", "2 ML Morphine Sulfate 0.5 MG/ML Injection" },
                { "1728792", "2 ML Morphine Sulfate 0.5 MG/ML Injection [Astramorph]" },
                { "1728800", "10 ML Morphine Sulfate 1 MG/ML Injection" },
                { "1728801", "10 ML Morphine Sulfate 1 MG/ML Injection [Astramorph]" },
                { "1728805", "2 ML Morphine Sulfate 1 MG/ML Injection" },
                { "1728806", "2 ML Morphine Sulfate 1 MG/ML Injection [Astramorph]" },
                { "1728999", "30 ML Morphine Sulfate 1 MG/ML Injection" },
                { "1729197", "1 ML Morphine Sulfate 2 MG/ML Cartridge" },
                { "1729320", "Fentanyl 0.3 MG/ACTUAT Metered Dose Nasal Spray" },
                { "1729322", "Fentanyl 0.3 MG/ACTUAT Metered Dose Nasal Spray [Lazanda]" },
                { "1729578", "remifentanil 1 MG Injection" },
                { "1729581", "remifentanil 1 MG Injection [Ultiva]" },
                { "1729584", "remifentanil 2 MG Injection" },
                { "1729586", "remifentanil 2 MG Injection [Ultiva]" },
                { "1729710", "remifentanil 5 MG Injection" },
                { "1729712", "remifentanil 5 MG Injection [Ultiva]" },
                { "1731517", "10 ML Morphine Sulfate 25 MG/ML Injection" },
                { "1731520", "4 ML Morphine Sulfate 25 MG/ML Injection" },
                { "1731522", "20 ML Morphine Sulfate 25 MG/ML Injection" },
                { "1731530", "1 ML Morphine Sulfate 15 MG/ML Injection" },
                { "1731537", "20 ML Morphine Sulfate 50 MG/ML Injection" },
                { "1731545", "50 ML Morphine Sulfate 50 MG/ML Injection" },
                { "1731986", "1 ML MORPHINE SULFATE LIPOSOMAL 10 MG/ML Injection" },
                { "1731987", "1 ML MORPHINE SULFATE LIPOSOMAL 10 MG/ML Injection [Depodur]" },
                { "1731990", "1.5 ML MORPHINE SULFATE LIPOSOMAL 10 MG/ML Injection" },
                { "1731991", "1.5 ML MORPHINE SULFATE LIPOSOMAL 10 MG/ML Injection [Depodur]" },
                { "1731993", "1 ML Morphine Sulfate 10 MG/ML Injection" },
                { "1731995", "1 ML Morphine Sulfate 10 MG/ML Cartridge" },
                { "1731998", "20 ML Morphine Sulfate 10 MG/ML Injection" },
                { "1731999", "20 ML Morphine Sulfate 10 MG/ML Injection [Infumorph]" },
                { "1732003", "1 ML Morphine Sulfate 8 MG/ML Cartridge" },
                { "1732006", "1 ML Morphine Sulfate 4 MG/ML Injection" },
                { "1732011", "1 ML Morphine Sulfate 8 MG/ML Injection" },
                { "1732014", "1 ML Morphine Sulfate 4 MG/ML Cartridge" },
                { "1732136", "1 ML Morphine Sulfate 5 MG/ML Injection" },
                { "1732138", "30 ML Morphine Sulfate 5 MG/ML Injection" },
                { "1733080", "1 ML Morphine Sulfate 15 MG/ML Cartridge" },
                { "1735003", "2 ML Fentanyl 0.05 MG/ML Injection" },
                { "1735006", "10 ML Fentanyl 0.05 MG/ML Injection" },
                { "1735007", "5 ML Fentanyl 0.05 MG/ML Injection" },
                { "1735008", "20 ML Fentanyl 0.05 MG/ML Injection" },
                { "1735013", "50 ML Fentanyl 0.05 MG/ML Injection" },
                {
                    "1745881",
                    "Abuse-Deterrent 12 HR Morphine Sulfate 15 MG Extended Release Oral Tablet [Morphabond]"
                },
                {
                    "1745886",
                    "Abuse-Deterrent 12 HR Morphine Sulfate 100 MG Extended Release Oral Tablet [Morphabond]"
                },
                {
                    "1745889",
                    "Abuse-Deterrent 12 HR Morphine Sulfate 30 MG Extended Release Oral Tablet [Morphabond]"
                },
                {
                    "1745892",
                    "Abuse-Deterrent 12 HR Morphine Sulfate 60 MG Extended Release Oral Tablet [Morphabond]"
                },
                { "1790527", "Abuse-Deterrent 12 HR Oxycodone 9 MG Extended Release Oral Capsule" },
                { "1790533", "Abuse-Deterrent 12 HR Oxycodone 9 MG Extended Release Oral Capsule [Xtampza]" },
                { "1791558", "Abuse-Deterrent 12 HR Oxycodone 13.5 MG Extended Release Oral Capsule" },
                { "1791560", "Abuse-Deterrent 12 HR Oxycodone 13.5 MG Extended Release Oral Capsule [Xtampza]" },
                { "1791567", "Abuse-Deterrent 12 HR Oxycodone 18 MG Extended Release Oral Capsule" },
                { "1791569", "Abuse-Deterrent 12 HR Oxycodone 18 MG Extended Release Oral Capsule [Xtampza]" },
                { "1791574", "Abuse-Deterrent 12 HR Oxycodone 27 MG Extended Release Oral Capsule" },
                { "1791576", "Abuse-Deterrent 12 HR Oxycodone 27 MG Extended Release Oral Capsule [Xtampza]" },
                { "1791580", "Abuse-Deterrent 12 HR Oxycodone 36 MG Extended Release Oral Capsule" },
                { "1791582", "Abuse-Deterrent 12 HR Oxycodone 36 MG Extended Release Oral Capsule [Xtampza]" },
                {
                    "1792707",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 40 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                { "1797650", "Buprenorphine 74.2 MG Drug Implant" },
                { "1797655", "Buprenorphine 74.2 MG Drug Implant [Probuphine]" },
                {
                    "1806701",
                    "12 HR Naltrexone hydrochloride 1.2 MG / Oxycodone Hydrochloride 10 MG Extended Release Oral Capsule"
                },
                {
                    "1806707",
                    "12 HR Naltrexone hydrochloride 1.2 MG / Oxycodone Hydrochloride 10 MG Extended Release Oral Capsule [Troxyca]"
                },
                {
                    "1806710",
                    "12 HR Naltrexone hydrochloride 2.4 MG / Oxycodone Hydrochloride 20 MG Extended Release Oral Capsule"
                },
                {
                    "1806716",
                    "12 HR Naltrexone hydrochloride 3.6 MG / Oxycodone Hydrochloride 30 MG Extended Release Oral Capsule"
                },
                {
                    "1806722",
                    "12 HR Naltrexone hydrochloride 4.8 MG / Oxycodone Hydrochloride 40 MG Extended Release Oral Capsule"
                },
                {
                    "1806728",
                    "12 HR Naltrexone hydrochloride 7.2 MG / Oxycodone Hydrochloride 60 MG Extended Release Oral Capsule"
                },
                {
                    "1806734",
                    "12 HR Naltrexone hydrochloride 9.6 MG / Oxycodone Hydrochloride 80 MG Extended Release Oral Capsule"
                },
                { "1809097", "1 ML Sufentanil 0.05 MG/ML Injection" },
                { "1809102", "2 ML Sufentanil 0.05 MG/ML Injection" },
                { "1809104", "5 ML Sufentanil 0.05 MG/ML Injection" },
                { "1809204", "Butorphanol Tartrate 2 MG/ML Injectable Solution [Torbugesic]" },
                { "1811473", "1 ML Pentazocine 30 MG/ML Injection" },
                { "1811475", "1 ML Pentazocine 30 MG/ML Injection [Talwin]" },
                {
                    "1812164", "Acetaminophen 325 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Tablet"
                },
                { "1860127", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 60 MG Extended Release Oral Tablet" },
                { "1860129", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 20 MG Extended Release Oral Tablet" },
                { "1860137", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 40 MG Extended Release Oral Tablet" },
                { "1860148", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 80 MG Extended Release Oral Tablet" },
                { "1860151", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 30 MG Extended Release Oral Tablet" },
                { "1860154", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 15 MG Extended Release Oral Tablet" },
                { "1860157", "Abuse-Deterrent 12 HR Oxycodone Hydrochloride 10 MG Extended Release Oral Tablet" },
                { "1860491", "12 HR Hydrocodone Bitartrate 10 MG Extended Release Oral Capsule" },
                { "1860492", "12 HR Hydrocodone Bitartrate 10 MG Extended Release Oral Capsule [Zohydro]" },
                { "1860493", "12 HR Hydrocodone Bitartrate 15 MG Extended Release Oral Capsule" },
                { "1860494", "12 HR Hydrocodone Bitartrate 15 MG Extended Release Oral Capsule [Zohydro]" },
                { "1860495", "12 HR Hydrocodone Bitartrate 20 MG Extended Release Oral Capsule" },
                { "1860496", "12 HR Hydrocodone Bitartrate 20 MG Extended Release Oral Capsule [Zohydro]" },
                { "1860497", "12 HR Hydrocodone Bitartrate 30 MG Extended Release Oral Capsule" },
                { "1860498", "12 HR Hydrocodone Bitartrate 30 MG Extended Release Oral Capsule [Zohydro]" },
                { "1860499", "12 HR Hydrocodone Bitartrate 40 MG Extended Release Oral Capsule" },
                { "1860500", "12 HR Hydrocodone Bitartrate 40 MG Extended Release Oral Capsule [Zohydro]" },
                { "1860501", "12 HR Hydrocodone Bitartrate 50 MG Extended Release Oral Capsule" },
                { "1860502", "12 HR Hydrocodone Bitartrate 50 MG Extended Release Oral Capsule [Zohydro]" },
                { "1864412", "Buprenorphine 0.7 MG / Naloxone 0.18 MG Sublingual Tablet" },
                { "1864414", "Buprenorphine 0.7 MG / Naloxone 0.18 MG Sublingual Tablet [Zubsolv]" },
                { "1866543", "1 ML Nalbuphine Hydrochloride 10 MG/ML Injection" },
                { "1866551", "1 ML Nalbuphine Hydrochloride 20 MG/ML Injection" },
                { "1871434", "Abuse-Deterrent 12 HR Morphine Sulfate 15 MG Extended Release Oral Tablet" },
                { "1871440", "Abuse-Deterrent 12 HR Morphine Sulfate 15 MG Extended Release Oral Tablet [Arymo]" },
                { "1871441", "Abuse-Deterrent 12 HR Morphine Sulfate 30 MG Extended Release Oral Tablet" },
                { "1871443", "Abuse-Deterrent 12 HR Morphine Sulfate 30 MG Extended Release Oral Tablet [Arymo]" },
                { "1871444", "Abuse-Deterrent 12 HR Morphine Sulfate 60 MG Extended Release Oral Tablet" },
                { "1871446", "Abuse-Deterrent 12 HR Morphine Sulfate 60 MG Extended Release Oral Tablet [Arymo]" },
                { "1872234", "Abuse-Deterrent 12 HR Morphine Sulfate 100 MG Extended Release Oral Tablet" },
                { "1872265", "1 ML Hydromorphone Hydrochloride 1 MG/ML Prefilled Syringe [Dilaudid]" },
                { "1872269", "1 ML Hydromorphone Hydrochloride 2 MG/ML Prefilled Syringe [Dilaudid]" },
                { "1872271", "1 ML Hydromorphone Hydrochloride 4 MG/ML Prefilled Syringe" },
                { "1872272", "1 ML Hydromorphone Hydrochloride 4 MG/ML Prefilled Syringe [Dilaudid]" },
                { "1872752", "0.5 ML Hydromorphone Hydrochloride 1 MG/ML Prefilled Syringe [Dilaudid]" },
                { "1944529", "Abuse-Deterrent Oxycodone Hydrochloride 15 MG Oral Tablet" },
                { "1944535", "Abuse-Deterrent Oxycodone Hydrochloride 15 MG Oral Tablet [Roxybond]" },
                { "1944538", "Abuse-Deterrent Oxycodone Hydrochloride 30 MG Oral Tablet" },
                { "1944540", "Abuse-Deterrent Oxycodone Hydrochloride 30 MG Oral Tablet [Roxybond]" },
                { "1944541", "Abuse-Deterrent Oxycodone Hydrochloride 5 MG Oral Tablet" },
                { "1944543", "Abuse-Deterrent Oxycodone Hydrochloride 5 MG Oral Tablet [Roxybond]" },
                { "1946525", "Matrix Delivery 24 HR tramadol hydrochloride 300 MG Extended Release Oral Tablet" },
                { "1946527", "Matrix Delivery 24 HR tramadol hydrochloride 200 MG Extended Release Oral Tablet" },
                { "1946529", "Matrix Delivery 24 HR tramadol hydrochloride 100 MG Extended Release Oral Tablet" },
                { "1947138", "Butorphanol 10 MG/ML Injectable Solution [Torphaject]" },
                { "197696", "72 HR Fentanyl 0.075 MG/HR Transdermal System" },
                { "197873", "Levorphanol 2 MG Oral Tablet" },
                { "198402", "Fentanyl 1.5 MG/ML Injectable Solution" },
                { "198403", "Fentanyl 2.5 MG/ML Injectable Solution" },
                { "1990745", "Methadone Hydrochloride 40 MG Tablet for Oral Suspension [Diskets]" },
                { "199400", "Codeine 50 MG/ML Injectable Solution" },
                {
                    "1995536",
                    "Acetaminophen 325 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Tablet [Panlor Reformulated Jan 2018]"
                },
                { "1996184", "0.5 ML Buprenorphine 200 MG/ML Prefilled Syringe" },
                { "1996189", "0.5 ML Buprenorphine 200 MG/ML Prefilled Syringe [Sublocade]" },
                { "1996192", "1.5 ML Buprenorphine 200 MG/ML Prefilled Syringe" },
                { "1996193", "1.5 ML Buprenorphine 200 MG/ML Prefilled Syringe [Sublocade]" },
                { "199789", "Pentazocine 50 MG Oral Tablet" },
                {
                    "2001623",
                    "Chlorpheniramine Maleate 0.8 MG/ML / Codeine Phosphate 2.4 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                { "200240", "paregoric 0.4 MG/ML Oral Solution" },
                { "2003714", "1 ML Morphine Sulfate 2 MG/ML Injection" },
                { "2045500", "Acetaminophen 300 MG / Oxycodone Hydrochloride 2.5 MG Oral Tablet [Nalocet]" },
                { "2055307", "20 ML Morphine Sulfate 10 MG/ML Injection [Mitigo]" },
                { "2055311", "20 ML Morphine Sulfate 25 MG/ML Injection [Mitigo]" },
                { "205533", "1 ML Buprenorphine 0.3 MG/ML Injection [Buprenex]" },
                {
                    "2056893",
                    "Chlorpheniramine Maleate 0.8 MG/ML / Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                { "2058257", "Buprenorphine 16 MG / Naloxone 4 MG Sublingual Film" },
                { "2058845", "Levorphanol Tartrate 3 MG Oral Tablet" },
                {
                    "2099286",
                    "12 HR Chlorpheniramine Maleate 8 MG / Codeine Phosphate 54.3 MG Extended Release Oral Tablet [Tuxarin]"
                },
                { "2105822", "Acetaminophen 60 MG/ML / Oxycodone Hydrochloride 2 MG/ML Oral Solution" },
                {
                    "2105929",
                    "Acetaminophen 325 MG / Caffeine 30 MG / dihydrocodeine bitartrate 16 MG Oral Tablet [Dvorah]"
                },
                { "2106368", "Buprenorphine 16 MG / Naloxone 4 MG Sublingual Film [Cassipa]" },
                {
                    "2182355",
                    "Chlorpheniramine Maleate 0.5 MG/ML / Hydrocodone Bitartrate 0.65 MG/ML / Phenylephrine Hydrochloride 1.6 MG/ML Oral Solution [Relasin HC]"
                },
                { "238129", "1 ML Buprenorphine 0.3 MG/ML Injection" },
                { "238133", "Pentazocine 30 MG/ML Injectable Solution" },
                { "245134", "72 HR Fentanyl 0.025 MG/HR Transdermal System" },
                { "245135", "72 HR Fentanyl 0.05 MG/HR Transdermal System" },
                { "245136", "72 HR Fentanyl 0.1 MG/HR Transdermal System" },
                { "246474", "Buprenorphine 0.2 MG Sublingual Tablet" },
                { "247626", "Oxycodone 10 MG Rectal Suppository" },
                { "247627", "Oxycodone 20 MG Rectal Suppository" },
                { "248307", "Oxycodone 30 MG Rectal Suppository" },
                { "250426", "Buprenorphine 0.4 MG Sublingual Tablet" },
                { "250473", "Heroin 10 MG Oral Tablet" },
                { "250485", "Pentazocine 25 MG Oral Tablet" },
                { "250486", "Pentazocine 50 MG Oral Capsule" },
                { "250877", "Pentazocine 50 MG Rectal Suppository" },
                { "250879", "Dextromoramide 5 MG Oral Tablet" },
                { "250880", "Dextromoramide 10 MG Oral Tablet" },
                { "251210", "Meptazinol 100 MG/ML Injectable Solution" },
                { "261106", "Fentanyl 0.2 MG Oral Lozenge [Actiq]" },
                { "261107", "Fentanyl 0.6 MG Oral Lozenge [Actiq]" },
                { "261108", "Fentanyl 0.8 MG Oral Lozenge [Actiq]" },
                { "261109", "Fentanyl 1.2 MG Oral Lozenge [Actiq]" },
                { "261110", "Fentanyl 1.6 MG Oral Lozenge [Actiq]" },
                { "261184", "72 HR Fentanyl 0.025 MG/HR Transdermal System [Duragesic]" },
                { "261185", "72 HR Fentanyl 0.05 MG/HR Transdermal System [Duragesic]" },
                { "261186", "72 HR Fentanyl 0.075 MG/HR Transdermal System [Duragesic]" },
                { "262071", "72 HR Fentanyl 0.1 MG/HR Transdermal System [Duragesic]" },
                { "262219", "Fentanyl 0.4 MG Oral Lozenge [Actiq]" },
                { "310292", "Fentanyl 0.1 MG Oral Lozenge" },
                { "310293", "Fentanyl 1.2 MG Oral Lozenge" },
                { "310294", "Fentanyl 1.6 MG Oral Lozenge" },
                { "310295", "Fentanyl 0.2 MG Oral Lozenge" },
                { "310296", "Fentanyl 0.3 MG Oral Lozenge" },
                { "310297", "Fentanyl 0.4 MG Oral Lozenge" },
                { "312104", "Belladonna Alkaloids 16.2 MG / Opium 30 MG Rectal Suppository" },
                { "312107", "Belladonna Alkaloids 16.2 MG / Opium 60 MG Rectal Suppository" },
                { "312288", "Acetaminophen 650 MG / Pentazocine 25 MG Oral Tablet" },
                { "312289", "Naloxone 0.5 MG / Pentazocine 50 MG Oral Tablet" },
                { "313992", "Fentanyl 0.6 MG Oral Lozenge" },
                { "313993", "Fentanyl 0.8 MG Oral Lozenge" },
                { "351264", "Buprenorphine 2 MG Sublingual Tablet" },
                { "351265", "Buprenorphine 8 MG Sublingual Tablet" },
                { "351266", "Buprenorphine 2 MG / Naloxone 0.5 MG Sublingual Tablet" },
                { "351267", "Buprenorphine 8 MG / Naloxone 2 MG Sublingual Tablet" },
                { "404414", "Buprenorphine 8 MG Sublingual Tablet [Subutex]" },
                { "577057", "72 HR Fentanyl 0.012 MG/HR Transdermal System" },
                { "583490", "72 HR Fentanyl 0.012 MG/HR Transdermal System [Duragesic]" },
                {
                    "637540",
                    "Aspirin 325 MG / Oxycodone Hydrochloride 4.5 MG / oxycodone terephthalate 0.38 MG Oral Tablet"
                },
                { "668363", "Fentanyl 0.1 MG Buccal Tablet" },
                { "668364", "Fentanyl 0.2 MG Buccal Tablet" },
                { "668365", "Fentanyl 0.4 MG Buccal Tablet" },
                { "668366", "Fentanyl 0.6 MG Buccal Tablet" },
                { "668367", "Fentanyl 0.8 MG Buccal Tablet" },
                { "668622", "Fentanyl 0.1 MG Buccal Tablet [Fentora]" },
                { "668624", "Fentanyl 0.2 MG Buccal Tablet [Fentora]" },
                { "668626", "Fentanyl 0.4 MG Buccal Tablet [Fentora]" },
                { "668628", "Fentanyl 0.6 MG Buccal Tablet [Fentora]" },
                { "668630", "Fentanyl 0.8 MG Buccal Tablet [Fentora]" },
                { "706898", "Fentanyl 0.3 MG Buccal Tablet" },
                {
                    "724614",
                    "Aspirin 325 MG / Oxycodone Hydrochloride 2.25 MG / oxycodone terephthalate 0.19 MG Oral Tablet"
                },
                { "727759", "2 ML Fentanyl 0.05 MG/ML Cartridge" },
                { "825409", "tapentadol 100 MG Oral Tablet" },
                { "825411", "tapentadol 50 MG Oral Tablet" },
                { "825413", "tapentadol 75 MG Oral Tablet" },
                { "827748", "propoxyphene napsylate 100 MG Oral Tablet" },
                { "827750", "propoxyphene napsylate 100 MG Oral Tablet [Darvon-N]" },
                { "827751", "Acetaminophen 325 MG / propoxyphene napsylate 100 MG Oral Tablet" },
                { "828576", "Acetaminophen 650 MG / propoxyphene napsylate 100 MG Oral Tablet" },
                { "828581", "Acetaminophen 650 MG / Propoxyphene Hydrochloride 65 MG Oral Tablet" },
                { "828585", "Aspirin 389 MG / Caffeine 32.4 MG / Propoxyphene Hydrochloride 32 MG Oral Capsule" },
                { "828594", "Aspirin 389 MG / Caffeine 32.4 MG / Propoxyphene Hydrochloride 65 MG Oral Capsule" },
                { "830196", "opium tincture 100 MG/ML Oral Solution" },
                { "833036", "Acetaminophen 750 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "833709", "24 HR tramadol hydrochloride 100 MG Extended Release Oral Tablet" },
                {
                    "833710",
                    "Matrix Delivery 24 HR tramadol hydrochloride 100 MG Extended Release Oral Tablet [Ryzolt]"
                },
                { "833711", "24 HR tramadol hydrochloride 200 MG Extended Release Oral Tablet" },
                {
                    "833712",
                    "Matrix Delivery 24 HR tramadol hydrochloride 200 MG Extended Release Oral Tablet [Ryzolt]"
                },
                { "833713", "24 HR tramadol hydrochloride 300 MG Extended Release Oral Tablet" },
                {
                    "833714",
                    "Matrix Delivery 24 HR tramadol hydrochloride 300 MG Extended Release Oral Tablet [Ryzolt]"
                },
                { "835603", "tramadol hydrochloride 50 MG Oral Tablet" },
                { "835605", "tramadol hydrochloride 50 MG Oral Tablet [Ultram]" },
                { "836395", "Acetaminophen 325 MG / tramadol hydrochloride 37.5 MG Oral Tablet" },
                { "836397", "Acetaminophen 325 MG / tramadol hydrochloride 37.5 MG Oral Tablet [Ultracet]" },
                { "836408", "tramadol hydrochloride 50 MG Disintegrating Oral Tablet" },
                { "836466", "tramadol hydrochloride 50 MG Oral Capsule" },
                { "836485", "tramadol hydrochloride 1 MG/ML Oral Solution" },
                { "845314", "24 HR tramadol hydrochloride 100 MG Extended Release Oral Tablet [Ultram]" },
                { "845315", "24 HR tramadol hydrochloride 200 MG Extended Release Oral Tablet [Ultram]" },
                { "845316", "24 HR tramadol hydrochloride 300 MG Extended Release Oral Tablet [Ultram]" },
                { "848768", "Aspirin 325 MG / Oxycodone Hydrochloride 4.84 MG Oral Tablet" },
                {
                    "848772",
                    "Aspirin 325 MG / Oxycodone Hydrochloride 4.84 MG Oral Tablet [Percodan Reformulated May 2009]"
                },
                {
                    "848928",
                    "Aspirin 325 MG / Oxycodone Hydrochloride 4.84 MG Oral Tablet [Endodan Reformulated May 2009]"
                },
                { "849279", "Propoxyphene Hydrochloride 65 MG Oral Capsule" },
                { "849293", "Acetaminophen 325 MG / Propoxyphene Hydrochloride 32.5 MG Oral Tablet" },
                { "849295", "Acetaminophen 325 MG / propoxyphene napsylate 50 MG Oral Tablet" },
                { "849303", "Acetaminophen 500 MG / propoxyphene napsylate 100 MG Extended Release Oral Tablet" },
                { "849304", "Acetaminophen 500 MG / propoxyphene napsylate 100 MG Oral Tablet" },
                { "849329", "tramadol hydrochloride 50 MG/ML Injectable Solution" },
                { "849331", "tramadol hydrochloride 75 MG Extended Release Oral Tablet" },
                { "849455", "Propoxyphene Hydrochloride 100 MG Oral Capsule" },
                { "849561", "12 HR tramadol hydrochloride 150 MG Extended Release Oral Tablet" },
                { "849903", "tramadol hydrochloride 50 MG Extended Release Oral Capsule" },
                { "854140", "tapentadol 100 MG Oral Tablet [Nucynta]" },
                { "854142", "tapentadol 50 MG Oral Tablet [Nucynta]" },
                { "854144", "tapentadol 75 MG Oral Tablet [Nucynta]" },
                { "856903", "Acetaminophen 500 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "856908", "Acetaminophen 660 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "856940", "Acetaminophen 21.7 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution" },
                { "856942", "Acetaminophen 21.7 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution [Hycet]" },
                { "856944", "Acetaminophen 21.7 MG/ML / Hydrocodone Bitartrate 0.67 MG/ML Oral Solution" },
                {
                    "856946", "Acetaminophen 21.7 MG/ML / Hydrocodone Bitartrate 0.67 MG/ML Oral Solution [Zamicet]"
                },
                { "856962", "Acetaminophen 500 MG / Hydrocodone Bitartrate 5 MG Oral Capsule" },
                { "856980", "Acetaminophen 300 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "856984", "Acetaminophen 300 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Xodol]" },
                { "856987", "Acetaminophen 300 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "856991", "Acetaminophen 300 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Xodol]" },
                { "856992", "Acetaminophen 300 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "856996", "Acetaminophen 300 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Xodol]" },
                { "856999", "Acetaminophen 325 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "857001", "Acetaminophen 325 MG / Hydrocodone Bitartrate 10 MG Oral Tablet [Norco]" },
                { "857002", "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "857004", "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Norco]" },
                { "857005", "Acetaminophen 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "857007", "Acetaminophen 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Norco]" },
                { "857076", "Acetaminophen 33.3 MG/ML / Hydrocodone Bitartrate 0.333 MG/ML Oral Solution" },
                { "857083", "Acetaminophen 650 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "857099", "Acetaminophen 33.3 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution" },
                { "857105", "Acetaminophen 33.3 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution [Lortab]" },
                { "857107", "Acetaminophen 500 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "857111", "Acetaminophen 500 MG / Hydrocodone Bitartrate 2.5 MG Oral Tablet" },
                { "857113", "Acetaminophen 500 MG / Hydrocodone Bitartrate 2.5 MG Oral Tablet [Lortab]" },
                { "857118", "Acetaminophen 500 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "857120", "Acetaminophen 500 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Lortab]" },
                { "857121", "Aspirin 500 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "857128", "Acetaminophen 400 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "857131", "Acetaminophen 400 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "857134", "Acetaminophen 400 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "857136", "Acetaminophen 400 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Zydone]" },
                { "857237", "Pentazocine 30 MG/ML Injectable Solution [Talwin]" },
                { "857370", "Acetaminophen 500 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Hy-Phen]" },
                { "857383", "Acetaminophen 650 MG / Hydrocodone Bitartrate 10 MG Oral Tablet" },
                { "857391", "Acetaminophen 325 MG / Hydrocodone Bitartrate 2.5 MG Oral Tablet" },
                { "857501", "Acetaminophen 556 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                {
                    "857510",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 4 MG / HYDROCODONE POLISTIREX 5 MG Extended Release Oral Capsule"
                },
                {
                    "857512",
                    "12 HR CHLORPHENIRAMINE POLISTIREX 8 MG / HYDROCODONE POLISTIREX 10 MG Extended Release Oral Capsule"
                },
                {
                    "857556",
                    "Brompheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.34 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "857575",
                    "Brompheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.34 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Bromplex HD]"
                },
                {
                    "857734",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.334 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution"
                },
                {
                    "857830",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.334 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution [Triant-HC]"
                },
                {
                    "857839",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.4 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution"
                },
                {
                    "857845",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.4 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [Hydro-PC II]"
                },
                { "858087", "Fentanyl 1.2 MG Buccal Film" },
                { "858092", "Fentanyl 0.2 MG Buccal Film" },
                { "858095", "Fentanyl 0.4 MG Buccal Film" },
                { "858098", "Fentanyl 0.6 MG Buccal Film" },
                { "858101", "Fentanyl 0.8 MG Buccal Film" },
                { "858770", "Hydrocodone Bitartrate 2.5 MG / Ibuprofen 200 MG Oral Tablet" },
                { "858772", "Hydrocodone Bitartrate 2.5 MG / Ibuprofen 200 MG Oral Tablet [Reprexain]" },
                { "858778", "Hydrocodone Bitartrate 5 MG / Ibuprofen 200 MG Oral Tablet" },
                { "858780", "Hydrocodone Bitartrate 5 MG / Ibuprofen 200 MG Oral Tablet [Ibudone]" },
                { "858784", "Hydrocodone Bitartrate 5 MG / Ibuprofen 200 MG Oral Tablet [Reprexain]" },
                { "858798", "Hydrocodone Bitartrate 7.5 MG / Ibuprofen 200 MG Oral Tablet" },
                { "858838", "Hydrocodone Bitartrate 7.5 MG / Ibuprofen 200 MG Oral Tablet [Vicoprofen]" },
                { "858939", "guaiacolsulfonate 24 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution" },
                {
                    "858945",
                    "guaiacolsulfonate 24 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution [Hydron EX]"
                },
                { "858953", "guaiacolsulfonate 30 MG/ML / Hydrocodone Bitartrate 0.6 MG/ML Oral Solution" },
                { "858967", "guaiacolsulfonate 60 MG/ML / Hydrocodone Bitartrate 0.9 MG/ML Oral Solution" },
                {
                    "858969", "guaiacolsulfonate 60 MG/ML / Hydrocodone Bitartrate 0.9 MG/ML Oral Solution [Hy-KXP]"
                },
                {
                    "858976",
                    "guaiacolsulfonate 60 MG/ML / Hydrocodone Bitartrate 0.9 MG/ML Oral Solution [Prolex DH]"
                },
                { "858991", "guaiacolsulfonate 60 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution" },
                {
                    "859019",
                    "guaiacolsulfonate 60 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution [Hydron KGS]"
                },
                {
                    "859027",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.7 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution"
                },
                {
                    "859029",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 0.7 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [Hydro-PC II]"
                },
                { "859097", "guaiacolsulfonate 70 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution" },
                { "859099", "guaiacolsulfonate 70 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution [KGS HC]" },
                {
                    "859137",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution"
                },
                {
                    "859141",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Phenylephrine Hydrochloride 1 MG/ML Oral Solution [B-Tuss]"
                },
                {
                    "859146",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                {
                    "859150",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution [Hydron CP]"
                },
                {
                    "859156",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                { "859315", "Hydrocodone Bitartrate 10 MG / Ibuprofen 200 MG Oral Tablet" },
                { "859317", "Hydrocodone Bitartrate 10 MG / Ibuprofen 200 MG Oral Tablet [Ibudone]" },
                { "859331", "Hydrocodone Bitartrate 10 MG / Ibuprofen 200 MG Oral Tablet [Reprexain]" },
                {
                    "859366",
                    "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution"
                },
                {
                    "859368",
                    "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [Nariz HC]"
                },
                {
                    "859376",
                    "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [Nazarin HC]"
                },
                { "859383", "Guaifenesin 40 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML Oral Solution" },
                {
                    "859939",
                    "Guaifenesin 45 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                {
                    "859943",
                    "Guaifenesin 45 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution [Simuc-HD]"
                },
                {
                    "860138",
                    "guaiacolsulfonate 30 MG/ML / Hydrocodone Bitartrate 0.6 MG/ML Oral Solution [De-Chlor NX]"
                },
                {
                    "860151",
                    "Hydrocodone Bitartrate 1 MG/ML / Phenylephrine 1 MG/ML / Pyrilamine 1 MG/ML Oral Solution"
                },
                {
                    "860159",
                    "Hydrocodone Bitartrate 1 MG/ML / Phenylephrine 1 MG/ML / Pyrilamine 1 MG/ML Oral Solution [De-Chlor MR]"
                },
                {
                    "860239",
                    "Guaifenesin 10 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Phenylephrine Hydrochloride 1.5 MG/ML Oral Solution [Hydro GP]"
                },
                {
                    "860426",
                    "Guaifenesin 20 MG/ML / Hydrocodone Bitartrate 0.4 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                {
                    "860530",
                    "Guaifenesin 20 MG/ML / Hydrocodone Bitartrate 0.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Su-Tuss HD]"
                },
                {
                    "860549",
                    "Guaifenesin 20 MG/ML / Hydrocodone Bitartrate 0.6 MG/ML / Pseudoephedrine Hydrochloride 3 MG/ML Oral Solution"
                },
                {
                    "860579",
                    "Guaifenesin 10 MG/ML / Hydrocodone Bitartrate 0.75 MG/ML / Pseudoephedrine Hydrochloride 4.5 MG/ML Oral Solution"
                },
                {
                    "860592",
                    "Guaifenesin 60 MG/ML / Hydrocodone Bitartrate 1 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution"
                },
                { "860593", "Hydrocodone Bitartrate 0.334 MG/ML / Phenylephrine 1 MG/ML Oral Solution" },
                {
                    "860596", "Hydrocodone Bitartrate 1 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                { "860599", "Hydrocodone Bitartrate 7.5 MG Oral Tablet" },
                { "860792", "1 ML Meperidine Hydrochloride 75 MG/ML Cartridge" },
                { "861447", "Meperidine Hydrochloride 10 MG/ML Injectable Solution" },
                { "861455", "Meperidine Hydrochloride 100 MG Oral Tablet" },
                { "861459", "Meperidine Hydrochloride 100 MG/ML Injectable Solution" },
                { "861463", "Meperidine Hydrochloride 50 MG/ML Injectable Solution" },
                { "861467", "Meperidine Hydrochloride 50 MG Oral Tablet" },
                { "861473", "1 ML Meperidine Hydrochloride 50 MG/ML Cartridge" },
                { "861476", "1 ML Meperidine Hydrochloride 25 MG/ML Injection" },
                { "861479", "Meperidine Hydrochloride 10 MG/ML Oral Solution" },
                { "861482", "1 ML Meperidine Hydrochloride 75 MG/ML Injection" },
                { "861493", "1 ML Meperidine Hydrochloride 100 MG/ML Cartridge" },
                { "861494", "1 ML Meperidine Hydrochloride 25 MG/ML Cartridge" },
                { "861517", "Meperidine Hydrochloride 100 MG Oral Tablet [Demerol]" },
                { "861520", "Meperidine Hydrochloride 100 MG/ML Injectable Solution [Demerol]" },
                { "861522", "Meperidine Hydrochloride 50 MG/ML Injectable Solution [Demerol]" },
                { "861525", "Meperidine Hydrochloride 50 MG Oral Tablet [Demerol]" },
                { "861529", "1 ML Meperidine Hydrochloride 50 MG/ML Cartridge [Demerol]" },
                { "861578", "Meperidine Hydrochloride 50 MG / Promethazine Hydrochloride 25 MG Oral Capsule" },
                { "861617", "1 ML Meperidine Hydrochloride 75 MG/ML Cartridge [Demerol]" },
                {
                    "863845",
                    "Abuse-Deterrent Morphine Sulfate 100 MG / Naltrexone hydrochloride 4 MG Extended Release Oral Capsule"
                },
                {
                    "863847",
                    "Abuse-Deterrent Morphine Sulfate 100 MG / Naltrexone hydrochloride 4 MG Extended Release Oral Capsule [Embeda]"
                },
                {
                    "863848",
                    "Abuse-Deterrent Morphine Sulfate 20 MG / Naltrexone hydrochloride 0.8 MG Extended Release Oral Capsule"
                },
                {
                    "863849",
                    "Abuse-Deterrent Morphine Sulfate 20 MG / Naltrexone hydrochloride 0.8 MG Extended Release Oral Capsule [Embeda]"
                },
                {
                    "863850",
                    "Abuse-Deterrent Morphine Sulfate 30 MG / Naltrexone hydrochloride 1.2 MG Extended Release Oral Capsule"
                },
                {
                    "863851",
                    "Abuse-Deterrent Morphine Sulfate 30 MG / Naltrexone hydrochloride 1.2 MG Extended Release Oral Capsule [Embeda]"
                },
                {
                    "863852",
                    "Abuse-Deterrent Morphine Sulfate 50 MG / Naltrexone hydrochloride 2 MG Extended Release Oral Capsule"
                },
                {
                    "863853",
                    "Abuse-Deterrent Morphine Sulfate 50 MG / Naltrexone hydrochloride 2 MG Extended Release Oral Capsule [Embeda]"
                },
                {
                    "863854",
                    "Abuse-Deterrent Morphine Sulfate 60 MG / Naltrexone hydrochloride 2.4 MG Extended Release Oral Capsule"
                },
                {
                    "863855",
                    "Abuse-Deterrent Morphine Sulfate 60 MG / Naltrexone hydrochloride 2.4 MG Extended Release Oral Capsule [Embeda]"
                },
                {
                    "863856",
                    "Abuse-Deterrent Morphine Sulfate 80 MG / Naltrexone hydrochloride 3.2 MG Extended Release Oral Capsule"
                },
                {
                    "863857",
                    "Abuse-Deterrent Morphine Sulfate 80 MG / Naltrexone hydrochloride 3.2 MG Extended Release Oral Capsule [Embeda]"
                },
                { "864706", "Methadone Hydrochloride 10 MG Oral Tablet" },
                { "864708", "Methadone Hydrochloride 10 MG Oral Tablet [Dolophine]" },
                { "864712", "Methadone Hydrochloride 10 MG Oral Tablet [Methadose]" },
                { "864714", "Methadone Hydrochloride 10 MG/ML Injectable Solution" },
                { "864718", "Methadone Hydrochloride 5 MG Oral Tablet" },
                { "864720", "Methadone Hydrochloride 5 MG Oral Tablet [Dolophine]" },
                { "864737", "Methadone Hydrochloride 5 MG Oral Tablet [Methadose]" },
                { "864761", "Methadone Hydrochloride 1 MG/ML Oral Solution" },
                { "864769", "Methadone Hydrochloride 2 MG/ML Oral Solution" },
                { "864978", "Methadone Hydrochloride 40 MG Tablet for Oral Suspension" },
                { "864980", "Methadone Hydrochloride 40 MG Tablet for Oral Suspension [Methadose]" },
                { "864984", "Methadone Hydrochloride 20 MG/ML Oral Solution" },
                { "886622", "Butorphanol Tartrate 2 MG/ML Injectable Solution" },
                { "886627", "1 ML Butorphanol Tartrate 1 MG/ML Injection" },
                { "886634", "Butorphanol Tartrate 1 MG/ACTUAT Metered Dose Nasal Spray" },
                {
                    "891172",
                    "Guaifenesin 20 MG/ML / Hydrocodone Bitartrate 0.4 MG/ML / Phenylephrine Hydrochloride 2 MG/ML Oral Solution [De-Chlor G]"
                },
                { "891874", "Morphine Sulfate 100 MG Extended Release Oral Tablet" },
                { "891878", "12 HR Morphine Sulfate 15 MG Extended Release Oral Tablet" },
                { "891881", "Morphine Sulfate 15 MG Extended Release Oral Tablet" },
                { "891883", "12 HR Morphine Sulfate 100 MG Extended Release Oral Tablet" },
                { "891885", "12 HR Morphine Sulfate 30 MG Extended Release Oral Tablet" },
                { "891888", "Morphine Sulfate 30 MG Extended Release Oral Tablet" },
                { "891890", "12 HR Morphine Sulfate 60 MG Extended Release Oral Tablet" },
                { "891893", "Morphine Sulfate 60 MG Extended Release Oral Tablet" },
                { "892297", "24 HR Morphine Sulfate 120 MG Extended Release Oral Capsule" },
                { "892299", "24 HR Morphine Sulfate 120 MG Extended Release Oral Capsule [Avinza]" },
                { "892342", "24 HR Morphine Sulfate 30 MG Extended Release Oral Capsule" },
                { "892344", "24 HR Morphine Sulfate 30 MG Extended Release Oral Capsule [Avinza]" },
                { "892345", "Morphine Sulfate 30 MG Extended Release Oral Capsule" },
                { "892349", "24 HR Morphine Sulfate 60 MG Extended Release Oral Capsule" },
                { "892351", "24 HR Morphine Sulfate 60 MG Extended Release Oral Capsule [Avinza]" },
                { "892352", "Morphine Sulfate 60 MG Extended Release Oral Capsule" },
                { "892355", "24 HR Morphine Sulfate 90 MG Extended Release Oral Capsule" },
                { "892357", "24 HR Morphine Sulfate 90 MG Extended Release Oral Capsule [Avinza]" },
                { "892473", "10 ML Morphine Sulfate 0.5 MG/ML Injection [Duramorph]" },
                { "892489", "10 ML Morphine Sulfate 1 MG/ML Injection [Duramorph]" },
                { "892494", "Morphine Sulfate 10 MG Extended Release Oral Capsule" },
                { "892496", "Morphine Sulfate 10 MG Extended Release Oral Capsule [Kadian]" },
                { "892516", "Morphine Sulfate 10 MG Rectal Suppository" },
                { "892531", "Morphine Sulfate 10 MG/ML Injectable Solution" },
                { "892554", "Morphine Sulfate 100 MG Extended Release Oral Capsule" },
                { "892556", "Morphine Sulfate 100 MG Extended Release Oral Capsule [Kadian]" },
                { "892560", "Morphine Sulfate 100 MG Extended Release Oral Tablet [MS Contin]" },
                { "892574", "Morphine Sulfate 15 MG Extended Release Oral Tablet [MS Contin]" },
                { "892579", "Morphine Sulfate 15 MG Oral Capsule" },
                { "892582", "Morphine Sulfate 15 MG Oral Tablet" },
                { "892589", "Morphine Sulfate 2 MG/ML Oral Solution" },
                { "892596", "Morphine Sulfate 20 MG Extended Release Oral Capsule" },
                { "892598", "Morphine Sulfate 20 MG Extended Release Oral Capsule [Kadian]" },
                { "892603", "Morphine Sulfate 20 MG Rectal Suppository" },
                { "892625", "Morphine Sulfate 20 MG/ML Oral Solution" },
                { "892643", "Morphine Sulfate 200 MG Extended Release Oral Capsule" },
                { "892645", "Morphine Sulfate 200 MG Extended Release Oral Capsule [Kadian]" },
                { "892646", "Morphine Sulfate 200 MG Extended Release Oral Tablet" },
                { "892648", "Morphine Sulfate 200 MG Extended Release Oral Tablet [MS Contin]" },
                { "892652", "20 ML Morphine Sulfate 25 MG/ML Injection [Infumorph]" },
                { "892658", "Morphine Sulfate 30 MG Extended Release Oral Capsule [Kadian]" },
                { "892660", "Morphine Sulfate 30 MG Extended Release Oral Tablet [MS Contin]" },
                { "892669", "Morphine Sulfate 30 MG Oral Capsule" },
                { "892672", "Morphine Sulfate 30 MG Oral Tablet" },
                { "892678", "Morphine Sulfate 30 MG Rectal Suppository" },
                { "894780", "Morphine Sulfate 4 MG/ML Oral Solution" },
                { "894801", "Morphine Sulfate 50 MG Extended Release Oral Capsule" },
                { "894803", "Morphine Sulfate 50 MG Extended Release Oral Capsule [Kadian]" },
                { "894805", "Morphine Sulfate 60 MG Extended Release Oral Capsule [Kadian]" },
                { "894807", "Morphine Sulfate 5 MG Rectal Suppository" },
                { "894813", "Morphine Sulfate 60 MG Extended Release Oral Tablet [MS Contin]" },
                { "894814", "Morphine Sulfate 80 MG Extended Release Oral Capsule" },
                { "894816", "Morphine Sulfate 80 MG Extended Release Oral Capsule [Kadian]" },
                { "894911", "0.7 ML Morphine Sulfate 14.3 MG/ML Auto-Injector" },
                { "894912", "1 ML Morphine Sulfate 10 MG/ML Prefilled Syringe" },
                { "894914", "1 ML Morphine Sulfate 8 MG/ML Prefilled Syringe" },
                { "894918", "12 HR Morphine Sulfate 200 MG Extended Release Oral Tablet" },
                { "894942", "24 HR Morphine Sulfate 45 MG Extended Release Oral Capsule" },
                { "894970", "24 HR Morphine Sulfate 75 MG Extended Release Oral Capsule" },
                { "894986", "Morphine Sulfate 0.4 MG/ML Oral Solution" },
                { "895014", "Morphine Sulfate 10 MG Oral Tablet" },
                { "895016", "Morphine Sulfate 10 MG/ML Oral Solution" },
                { "895022", "Morphine Sulfate 100 MG Rectal Suppository" },
                { "895185", "Morphine Sulfate 15 MG Rectal Suppository" },
                { "895194", "Morphine Sulfate 15 MG/ML Injectable Solution" },
                { "895199", "Morphine Sulfate 2 MG/ML Oral Suspension" },
                { "895201", "Morphine Sulfate 20 MG Oral Tablet" },
                { "895202", "Morphine Sulfate 20 MG/ML Injectable Solution" },
                { "895206", "Morphine Sulfate 200 MG Oral Tablet" },
                { "895208", "Morphine Sulfate 3 MG/ML Oral Suspension" },
                { "895213", "Morphine Sulfate 30 MG/ML Injectable Solution" },
                { "895215", "Morphine Sulfate 35 MG Rectal Suppository" },
                { "895217", "Morphine Sulfate 5 MG Extended Release Oral Tablet" },
                { "895219", "Morphine Sulfate 5 MG/ML Oral Suspension" },
                { "895221", "Morphine Sulfate 50 MG Oral Tablet" },
                { "895227", "Morphine Sulfate 50 MG Rectal Suppository" },
                { "895238", "Morphine Sulfate 6 MG/ML Oral Solution" },
                { "895240", "Morphine Sulfate 6.67 MG/ML Oral Suspension" },
                { "895247", "Morphine Sulfate 60 MG Oral Tablet" },
                { "895248", "Morphine Sulfate 75 MG Rectal Suppository" },
                { "895861", "Morphine Sulfate 25 MG Oral Tablet" },
                { "895867", "Morphine hydrochloride 40 MG Oral Tablet" },
                { "895869", "Morphine Sulfate 5 MG Oral Tablet" },
                { "895871", "Morphine Sulfate 50 MG/ML Oral Solution" },
                { "895975", "MORPHINE SULFATE LIPOSOMAL 10 MG/ML Injectable Solution" },
                { "897653", "1 ML Hydromorphone Hydrochloride 1 MG/ML Injection" },
                { "897657", "Hydromorphone Hydrochloride 1 MG/ML Oral Solution" },
                { "897658", "Hydromorphone Hydrochloride 1 MG/ML Oral Solution [Dilaudid]" },
                { "897696", "Hydromorphone Hydrochloride 2 MG Oral Tablet" },
                { "897698", "Hydromorphone Hydrochloride 2 MG Oral Tablet [Dilaudid]" },
                { "897702", "Hydromorphone Hydrochloride 4 MG Oral Tablet" },
                { "897704", "Hydromorphone Hydrochloride 4 MG Oral Tablet [Dilaudid]" },
                { "897710", "Hydromorphone Hydrochloride 8 MG Oral Tablet" },
                { "897712", "Hydromorphone Hydrochloride 8 MG Oral Tablet [Dilaudid]" },
                { "897745", "Hydromorphone Hydrochloride 2 MG/ML Injectable Solution" },
                { "897747", "1 ML Hydromorphone Hydrochloride 2 MG/ML Injection [Dilaudid]" },
                { "897749", "Hydromorphone Hydrochloride 3 MG Rectal Suppository" },
                { "897753", "1 ML Hydromorphone Hydrochloride 4 MG/ML Injection" },
                { "897755", "1 ML Hydromorphone Hydrochloride 4 MG/ML Injection [Dilaudid]" },
                { "897756", "1 ML Hydromorphone Hydrochloride 1 MG/ML Prefilled Syringe" },
                { "897757", "1 ML Hydromorphone Hydrochloride 2 MG/ML Prefilled Syringe" },
                { "897758", "1 ML Hydromorphone Hydrochloride 4 MG/ML Cartridge" },
                { "897771", "Hydromorphone Hydrochloride 1 MG Oral Tablet" },
                { "898004", "Hydromorphone Hydrochloride 1.3 MG Oral Capsule" },
                { "898138", "Hydromorphone Hydrochloride 2.6 MG Oral Capsule" },
                { "898139", "Hydromorphone Hydrochloride 3 MG Oral Tablet" },
                { "898611", "12 HR Hydromorphone Hydrochloride 2 MG Extended Release Oral Capsule" },
                { "898612", "12 HR Hydromorphone Hydrochloride 3 MG Extended Release Oral Capsule" },
                { "898614", "12 HR Hydromorphone Hydrochloride 4 MG Extended Release Oral Capsule" },
                { "898618", "12 HR Hydromorphone Hydrochloride 8 MG Extended Release Oral Capsule" },
                { "898624", "Hydromorphone Hydrochloride 30 MG Extended Release Oral Capsule" },
                { "902729", "24 HR Hydromorphone Hydrochloride 12 MG Extended Release Oral Tablet" },
                { "902733", "24 HR Hydromorphone Hydrochloride 12 MG Extended Release Oral Tablet [Exalgo]" },
                { "902736", "24 HR Hydromorphone Hydrochloride 16 MG Extended Release Oral Tablet" },
                { "902738", "24 HR Hydromorphone Hydrochloride 16 MG Extended Release Oral Tablet [Exalgo]" },
                { "902741", "24 HR Hydromorphone Hydrochloride 8 MG Extended Release Oral Tablet" },
                { "902743", "24 HR Hydromorphone Hydrochloride 8 MG Extended Release Oral Tablet [Exalgo]" },
                { "904415", "Nalbuphine Hydrochloride 10 MG/ML Injectable Solution" },
                { "904440", "Nalbuphine Hydrochloride 20 MG/ML Injectable Solution" },
                { "904870", "168 HR Buprenorphine 0.01 MG/HR Transdermal System" },
                { "904874", "168 HR Buprenorphine 0.01 MG/HR Transdermal System [BuTrans]" },
                { "904876", "168 HR Buprenorphine 0.02 MG/HR Transdermal System" },
                { "904878", "168 HR Buprenorphine 0.02 MG/HR Transdermal System [BuTrans]" },
                { "904880", "168 HR Buprenorphine 0.005 MG/HR Transdermal System" },
                { "904882", "168 HR Buprenorphine 0.005 MG/HR Transdermal System [BuTrans]" },
                { "977874", "12 HR Oxymorphone Hydrochloride 10 MG Extended Release Oral Tablet" },
                { "977876", "12 HR Oxymorphone Hydrochloride 10 MG Extended Release Oral Tablet [Opana]" },
                { "977894", "12 HR Oxymorphone Hydrochloride 15 MG Extended Release Oral Tablet" },
                { "977896", "12 HR Oxymorphone Hydrochloride 15 MG Extended Release Oral Tablet [Opana]" },
                { "977902", "12 HR Oxymorphone Hydrochloride 20 MG Extended Release Oral Tablet" },
                { "977904", "12 HR Oxymorphone Hydrochloride 20 MG Extended Release Oral Tablet [Opana]" },
                { "977909", "12 HR Oxymorphone Hydrochloride 30 MG Extended Release Oral Tablet" },
                { "977911", "12 HR Oxymorphone Hydrochloride 30 MG Extended Release Oral Tablet [Opana]" },
                { "977915", "12 HR Oxymorphone Hydrochloride 40 MG Extended Release Oral Tablet" },
                { "977917", "12 HR Oxymorphone Hydrochloride 40 MG Extended Release Oral Tablet [Opana]" },
                { "977923", "12 HR Oxymorphone Hydrochloride 5 MG Extended Release Oral Tablet" },
                { "977925", "12 HR Oxymorphone Hydrochloride 5 MG Extended Release Oral Tablet [Opana]" },
                { "977929", "12 HR Oxymorphone Hydrochloride 7.5 MG Extended Release Oral Tablet" },
                { "977931", "12 HR Oxymorphone Hydrochloride 7.5 MG Extended Release Oral Tablet [Opana]" },
                { "977935", "1 ML Oxymorphone Hydrochloride 1 MG/ML Injection" },
                { "977937", "1 ML Oxymorphone Hydrochloride 1 MG/ML Injection [Opana]" },
                { "977939", "Oxymorphone Hydrochloride 5 MG Oral Tablet" },
                { "977940", "Oxymorphone Hydrochloride 5 MG Oral Tablet [Opana]" },
                { "977942", "Oxymorphone Hydrochloride 10 MG Oral Tablet" },
                { "977943", "Oxymorphone Hydrochloride 10 MG Oral Tablet [Opana]" },
                { "991147", "Methadone Hydrochloride 10 MG/ML Oral Solution" },
                { "991149", "Methadone Hydrochloride 10 MG/ML Oral Solution [Methadose]" },
                { "991486", "Codeine Phosphate 2 MG/ML / Promethazine Hydrochloride 1.25 MG/ML Oral Solution" },
                { "992656", "homatropine methylbromide 1.5 MG / Hydrocodone Bitartrate 5 MG Oral Tablet" },
                { "992668", "homatropine methylbromide 0.3 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution" },
                {
                    "992671",
                    "homatropine methylbromide 0.3 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution [Hycodan]"
                },
                {
                    "992675",
                    "homatropine methylbromide 0.3 MG/ML / Hydrocodone Bitartrate 1 MG/ML Oral Solution [Hydromet]"
                },
                {
                    "992733",
                    "homatropine methylbromide 1.5 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Tussigon]"
                },
                { "993755", "Acetaminophen 24 MG/ML / Codeine Phosphate 2.4 MG/ML Oral Solution" },
                { "993763", "Acetaminophen 24 MG/ML / Codeine Phosphate 2.4 MG/ML Oral Suspension" },
                {
                    "993767",
                    "Acetaminophen 24 MG/ML / Codeine Phosphate 2.4 MG/ML Oral Suspension [Capital and Codeine]"
                },
                { "993770", "Acetaminophen 300 MG / Codeine Phosphate 15 MG Oral Tablet" },
                { "993781", "Acetaminophen 300 MG / Codeine Phosphate 30 MG Oral Tablet" },
                { "993837", "Acetaminophen 300 MG / Codeine Phosphate 30 MG Oral Tablet [Tylenol with Codeine]" },
                { "993890", "Acetaminophen 300 MG / Codeine Phosphate 60 MG Oral Tablet" },
                { "993892", "Acetaminophen 300 MG / Codeine Phosphate 60 MG Oral Tablet [Tylenol with Codeine]" },
                {
                    "993943",
                    "Acetaminophen 325 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule"
                },
                { "994043", "Acetaminophen 500 MG / Codeine Phosphate 15 MG Oral Tablet" },
                { "994045", "Acetaminophen 500 MG / Codeine Phosphate 15 MG Oral Tablet [Codrix]" },
                { "994046", "Acetaminophen 500 MG / Codeine Phosphate 30 MG Oral Tablet" },
                { "994048", "Acetaminophen 500 MG / Codeine Phosphate 30 MG Oral Tablet [Codrix]" },
                { "994049", "Acetaminophen 500 MG / Codeine Phosphate 60 MG Oral Tablet" },
                { "994051", "Acetaminophen 500 MG / Codeine Phosphate 60 MG Oral Tablet [Codrix]" },
                { "994226", "Aspirin 325 MG / Carisoprodol 200 MG / Codeine Phosphate 16 MG Oral Tablet" },
                {
                    "994237",
                    "Aspirin 325 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule"
                },
                {
                    "994239",
                    "Aspirin 325 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule [Ascomp]"
                },
                {
                    "994277",
                    "Aspirin 325 MG / butalbital 50 MG / Caffeine 40 MG / Codeine Phosphate 30 MG Oral Capsule [Fiorinal with Codeine]"
                },
                {
                    "994289",
                    "Brompheniramine Maleate 0.27 MG/ML / Codeine Phosphate 1.27 MG/ML / Pseudoephedrine Hydrochloride 2 MG/ML Oral Solution"
                },
                {
                    "994402",
                    "Brompheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "994404",
                    "Brompheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.5 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Mar-cof BP]"
                },
                {
                    "995041",
                    "Chlorpheniramine Maleate 0.2 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 3 MG/ML Oral Suspension"
                },
                {
                    "995043",
                    "Chlorpheniramine Maleate 0.2 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 3 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995062", "Chlorpheniramine Maleate 0.2 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995064",
                    "Chlorpheniramine Maleate 0.2 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                {
                    "995065",
                    "Chlorpheniramine Maleate 0.222 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 3.33 MG/ML Oral Suspension"
                },
                {
                    "995067",
                    "Chlorpheniramine Maleate 0.222 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 3.33 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995068", "Chlorpheniramine Maleate 0.222 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995070",
                    "Chlorpheniramine Maleate 0.222 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                { "995071", "Chlorpheniramine Maleate 0.25 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995073",
                    "Chlorpheniramine Maleate 0.25 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                {
                    "995075",
                    "Chlorpheniramine Maleate 0.25 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 0.375 MG/ML Oral Suspension"
                },
                {
                    "995077",
                    "Chlorpheniramine Maleate 0.25 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 0.375 MG/ML Oral Suspension [Zodryl DAC]"
                },
                {
                    "995079",
                    "Chlorpheniramine Maleate 0.266 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Suspension"
                },
                {
                    "995081",
                    "Chlorpheniramine Maleate 0.266 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 4 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995082", "Chlorpheniramine Maleate 0.267 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995084",
                    "Chlorpheniramine Maleate 0.267 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                {
                    "995086",
                    "Chlorpheniramine Maleate 0.286 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 4.29 MG/ML Oral Suspension"
                },
                {
                    "995088",
                    "Chlorpheniramine Maleate 0.286 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 4.29 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995093", "Chlorpheniramine Maleate 0.286 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995095",
                    "Chlorpheniramine Maleate 0.286 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                {
                    "995108",
                    "Chlorpheniramine Maleate 0.333 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 5 MG/ML Oral Suspension"
                },
                {
                    "995110",
                    "Chlorpheniramine Maleate 0.333 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 5 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995116", "Chlorpheniramine Maleate 0.333 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995118",
                    "Chlorpheniramine Maleate 0.333 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                {
                    "995120",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Suspension"
                },
                {
                    "995122",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Suspension [Zodryl DAC]"
                },
                { "995123", "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension" },
                {
                    "995125",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1 MG/ML Oral Suspension [Zodryl AC]"
                },
                { "995128", "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.8 MG/ML Oral Solution" },
                {
                    "995132",
                    "Chlorpheniramine Maleate 0.4 MG/ML / Codeine Phosphate 1.8 MG/ML Oral Solution [Z Tuss AC]"
                },
                { "995226", "Codeine Phosphate 0.5 MG/ML / Guaifenesin 15 MG/ML Oral Solution" },
                { "995438", "Codeine Phosphate 1.26 MG/ML / Guaifenesin 20 MG/ML Oral Solution" },
                { "995440", "Codeine Phosphate 1.26 MG/ML / Guaifenesin 20 MG/ML Oral Solution [M-Clear WC]" },
                { "995441", "Codeine Phosphate 1.5 MG/ML / Guaifenesin 45 MG/ML Oral Solution" },
                { "995443", "Codeine Phosphate 1.5 MG/ML / Guaifenesin 45 MG/ML Oral Solution [Mar-cof CG]" },
                { "995447", "Codeine Phosphate 1.8 MG/ML / Pyrilamine Maleate 1.67 MG/ML Oral Solution" },
                { "995450", "Codeine Phosphate 10 MG / Guaifenesin 300 MG Oral Tablet" },
                { "995476", "Codeine Phosphate 10 MG / Guaifenesin 400 MG Oral Tablet" },
                { "995478", "Codeine Phosphate 10 MG / Guaifenesin 400 MG Oral Tablet [Allfen CD]" },
                { "995483", "Codeine Phosphate 2 MG/ML / Guaifenesin 40 MG/ML Oral Solution" },
                { "995868", "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution" },
                { "995872", "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Cheratussin]" },
                { "995936", "Codeine Phosphate 10 MG / Guaifenesin 300 MG Oral Tablet [Brontex]" },
                { "995940", "Codeine Phosphate 0.5 MG/ML / Guaifenesin 15 MG/ML Oral Solution [Brontex]" },
                {
                    "995956",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Cheracol with Codeine]"
                },
                {
                    "995983",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution"
                },
                {
                    "995985",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Biotussin]"
                },
                {
                    "995993",
                    "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML Oral Solution [Cheratussin DAC]"
                },
                { "996462", "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Guiatuss AC]" },
                { "996481", "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Mytussin AC]" },
                { "996484", "Codeine Phosphate 2 MG/ML / Guaifenesin 20 MG/ML Oral Solution [Robafen AC]" },
                { "996512", "Codeine Phosphate 2 MG/ML / Guaifenesin 60 MG/ML Oral Solution" },
                {
                    "996580",
                    "Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 1 MG/ML / Pyrilamine Maleate 1 MG/ML Oral Solution"
                },
                {
                    "996584",
                    "Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 1 MG/ML / Pyrilamine Maleate 1 MG/ML Oral Solution [Zotex C]"
                },
                {
                    "996640",
                    "Codeine Phosphate 2 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML / Triprolidine Hydrochloride 0.25 MG/ML Oral Solution"
                },
                {
                    "996648",
                    "Codeine Phosphate 2 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML / Triprolidine Hydrochloride 0.25 MG/ML Oral Solution [Pseudodine C]"
                },
                {
                    "996650",
                    "Codeine Phosphate 2 MG/ML / Pseudoephedrine Hydrochloride 6 MG/ML / Triprolidine Hydrochloride 0.25 MG/ML Oral Solution [Triacin C]"
                },
                {
                    "996706",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet"
                },
                {
                    "996708",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Phenylephrine Hydrochloride 10 MG Oral Tablet [Maxiphen CDX]"
                },
                {
                    "996710",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 20 MG Oral Tablet"
                },
                {
                    "996712",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 20 MG Oral Tablet [Ambifed-G CD]"
                },
                {
                    "996714",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet"
                },
                {
                    "996716",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 30 MG Oral Tablet [Ambifed CD]"
                },
                {
                    "996718",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 40 MG Oral Tablet"
                },
                {
                    "996720",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 40 MG Oral Tablet [Maxifed-G CD]"
                },
                {
                    "996722",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet"
                },
                {
                    "996724",
                    "Codeine Phosphate 20 MG / Guaifenesin 400 MG / Pseudoephedrine Hydrochloride 60 MG Oral Tablet [Maxifed CD]"
                },
                { "996725", "Codeine Phosphate 20 MG / Guaifenesin 400 MG Oral Tablet" },
                { "996727", "Codeine Phosphate 20 MG / Guaifenesin 400 MG Oral Tablet [Allfen CDX]" },
                { "996728", "Codeine Phosphate 20 MG / Pseudoephedrine Hydrochloride 60 MG Oral Capsule" },
                {
                    "996730", "Codeine Phosphate 20 MG / Pseudoephedrine Hydrochloride 60 MG Oral Capsule [Nucofed]"
                },
                { "996734", "Codeine Phosphate 5 MG/ML Oral Solution" },
                { "996736", "Codeine Phosphate 9 MG / Guaifenesin 200 MG Oral Capsule" },
                { "996738", "Codeine Phosphate 9 MG / Guaifenesin 200 MG Oral Capsule [M-Clear WC]" },
                {
                    "996757",
                    "Codeine Phosphate 2 MG/ML / Phenylephrine Hydrochloride 1 MG/ML / Promethazine Hydrochloride 1.25 MG/ML Oral Solution"
                },
                { "996976", "Acetaminophen 500 MG / Codeine Phosphate 12.8 MG Oral Tablet" },
                { "996978", "Acetaminophen 500 MG / Codeine Phosphate 13.5 MG Oral Tablet" },
                { "996979", "Acetaminophen 500 MG / Codeine Phosphate 30 MG Oral Capsule" },
                { "996981", "Acetaminophen 500 MG / Codeine Phosphate 8 MG Oral Capsule" },
                { "996982", "Acetaminophen 500 MG / Codeine Phosphate 8 MG Oral Tablet" },
                { "996983", "Acetaminophen 650 MG / Codeine Phosphate 60 MG Oral Tablet" },
                { "996988", "Aspirin 300 MG / Codeine Phosphate 8 MG Oral Tablet" },
                { "996991", "Aspirin 325 MG / Codeine Phosphate 30 MG Oral Tablet" },
                { "996994", "Aspirin 325 MG / Codeine Phosphate 60 MG Oral Tablet" },
                {
                    "996998",
                    "Brompheniramine Maleate 0.266 MG/ML / Codeine Phosphate 1.27 MG/ML / Phenylephrine Hydrochloride 0.666 MG/ML Oral Solution"
                },
                { "997019", "Codeine Phosphate 1 MG/ML / Kaolin 300 MG/ML Oral Suspension" },
                { "997164", "Codeine Phosphate 12.5 MG / Ibuprofen 200 MG Oral Tablet" },
                { "997165", "Codeine Phosphate 12.8 MG / Ibuprofen 200 MG Oral Tablet" },
                { "997169", "Codeine Phosphate 15 MG Oral Tablet" },
                { "997170", "Codeine sulfate 15 MG Oral Tablet" },
                { "997280", "Codeine Phosphate 20 MG / Ibuprofen 300 MG Extended Release Oral Tablet" },
                { "997284", "Codeine Phosphate 3 MG/ML Oral Solution" },
                { "997285", "Codeine Phosphate 30 MG Oral Tablet" },
                { "997287", "Codeine sulfate 30 MG Oral Tablet" },
                { "997296", "Codeine sulfate 60 MG Oral Tablet" },
                { "997301", "Codeine Phosphate 60 MG Oral Tablet" },
                { "997303", "Codeine Phosphate 60 MG/ML Injectable Solution" },
                { "997398", "Codeine Phosphate 2 MG/ML Oral Solution" },
                { "998212", "1 ML Morphine Sulfate 2 MG/ML Prefilled Syringe" },
                { "998213", "1 ML Morphine Sulfate 4 MG/ML Prefilled Syringe" },
                { "999729", "Acetaminophen 250 MG / tramadol hydrochloride 50 MG Oral Capsule" }
            };
        }

        public static Dictionary<string, string> Codes { get; }
    }
}