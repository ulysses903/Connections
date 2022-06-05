using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class Network
    {
        public int NumberOfElements { get; private set; }
        public List<Relationship> RelationshipList { get; private set; }

        public Network(int numberOfElements)
        {
            checkNumberOfElements(numberOfElements);
            NumberOfElements = numberOfElements;
            RelationshipList = new List<Relationship>();
        }

        public void connect(int startElement, int endElement)
        {
            checkRelationalRules(startElement, endElement);
            Relationship relationship = new Relationship(startElement, endElement);
            RelationshipList.Add(relationship);
        }

        public Boolean query(int startElement, int endElement)
        {
            checkRelationalRules(startElement, endElement);
            List<int> relationshipList = new List<int>();
            List<int> validatedList = new List<int>();
            int elementOnCheck = startElement;

            while (elementOnCheck != 0)
            {
                findAllRelationsOfStartElementNotIncluded(elementOnCheck, relationshipList);
                findAllRelationsOfEndElementNotIncluded(elementOnCheck, relationshipList);
                if (relationshipList.Any(element => element == endElement))
                {
                    return true;
                }
                validatedList.Add(elementOnCheck);
                elementOnCheck = getFirstElementNotValidated(relationshipList, validatedList);
            }
            return false;
        }

        private void checkNumberOfElements(int numberOfElements)
        {
            if (numberOfElements <= 1)
                throw new Exception("Quantidade de elementos deve no minimo maior que um.");
        }

        private void checkRelationalRules(int startElement, int endElement)
        {
            if (startElement <= 0 || startElement > NumberOfElements)
            {
                throw new Exception("Elemento inicial deve ser positiva e menor que a quantidade de elementos.");
            }
            if (endElement <= 0 || endElement > NumberOfElements)
            {
                throw new Exception("Elemento final deve ser positiva e menor que a quantidade de elementos.");
            }
        }

        private int getFirstElementNotValidated(List<int> relationshipList, List<int> validatedList)
        {
            return relationshipList.Except(validatedList).FirstOrDefault();
        }

        private void findAllRelationsOfStartElementNotIncluded(int elementOnCheck, List<int> relationshipList)
        {
            var listaTeste = RelationshipList.Where(relacionamento => relacionamento.StartElement == elementOnCheck).Select(relationship => relationship.EndElement);
            relationshipList.AddRange(listaTeste.Except(relationshipList));
        }

        private void findAllRelationsOfEndElementNotIncluded(int elementOnCheck, List<int> relationshipList)
        {
            var listaTeste = RelationshipList.Where(relacionamento => relacionamento.EndElement == elementOnCheck).Select(relationship => relationship.StartElement);
            relationshipList.AddRange(listaTeste.Except(relationshipList));
        }
    }
}
